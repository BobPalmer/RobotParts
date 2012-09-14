using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invoicing.Model;
using Invoicing.Tasks;
using Invoicing.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Invoicing.Tests.Unit
{
    [TestClass]
    public class When_calculating_order_lines
    {
        [ClassInitialize]
        public static void ClassSetup(TestContext TestContext)
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        [TestMethod]
        public void Should_be_able_to_calculate_discount_percentages()
        {
            var line = new PartData {DiscountPercent = .25M, Quantity = 1, UnitPrice = 100};
            var expectedBalance = 75M;
            line = DefaultContext.FinanceTask.CalculateLineTotals(line);
            Assert.AreEqual(expectedBalance,line.FinancedAmount);
        }

        [TestMethod]
        public void Should_be_able_to_calculate_extended_costs()
        {
            var line = new PartData { DiscountPercent = .25M, Quantity = 2, UnitPrice = 100 };
            var expectedBalance = 150M;
            line = DefaultContext.FinanceTask.CalculateLineTotals(line);
            Assert.AreEqual(expectedBalance, line.FinancedAmount);
        }

        [TestMethod]
        public void Should_be_able_to_load_missing_part_data()
        {
            var line = new PartData {PartName = "Basic Microcontroller"};
            line = DefaultContext.FinanceTask.LoadLineData(line);
            Assert.AreEqual(.1M,line.UpfrontPercent);
            Assert.AreEqual(125M,line.UnitPrice);
        }

        [TestMethod]
        public void Should_calculate_amount_down_after_discount()
        {
            var line = new PartData { DiscountPercent = .25M, Quantity = 1, UnitPrice = 100, UpfrontPercent = .1M};
            var expectedBalance = 67.5M;
            var expectedDue = 7.5M;
            line = DefaultContext.FinanceTask.CalculateLineTotals(line);
            Assert.AreEqual(expectedBalance, line.FinancedAmount);
            Assert.AreEqual(expectedDue, line.UpfrontAmount);        
        }
    }

    [TestClass]
    public class When_Applying_Credits_and_Gift_Certificates
    {
        [ClassInitialize]
        public static void ClassSetup(TestContext TestContext)
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        [TestMethod]
        public void Should_combine_all_parts_into_summary_data()
        {
            var paydat = new PaymentData();
            paydat.Parts = new PartData[3];
            paydat.Parts[0] = DefaultContext.FinanceTask.CalculateLineTotals(new PartData { DiscountPercent = .25M, Quantity = 3, UnitPrice = 150, UpfrontPercent = 0M });
            paydat.Parts[1] = DefaultContext.FinanceTask.CalculateLineTotals(new PartData { DiscountPercent = 0M, Quantity = 2, UnitPrice = 125, UpfrontPercent = .1M });
            paydat.Parts[2] = DefaultContext.FinanceTask.CalculateLineTotals(new PartData { DiscountPercent = .10M, Quantity = 4, UnitPrice = 210, UpfrontPercent = .15M });

            var expectedUpfront = 138.4M;
            var expectedFinanced = 1205.1M;

            paydat = DefaultContext.FinanceTask.CombineLineData(paydat);

            Assert.AreEqual(expectedFinanced, paydat.FinancedTotal);
            Assert.AreEqual(expectedUpfront, paydat.UpfrontTotal);
        }
        
        [TestMethod]
        public void Should_apply_gift_certificates_to_down_payment()
        {
            var paydat = new PaymentData()
                             {
                                 FinancedTotal = 1000,
                                 UpfrontTotal = 500,
                                 GiftCardAmount = 100,
                             };
            paydat = DefaultContext.FinanceTask.ApplyGiftCertificate(paydat);

            var expectedFinanced = 1000; //1000 or 900
            var expectedUpfront = 400; //400 or 500
            var expectedGift = 0;

            Assert.AreEqual(expectedGift,paydat.GiftCardAmount);
            Assert.AreEqual(expectedUpfront, paydat.UpfrontTotal);
            Assert.AreEqual(expectedFinanced, paydat.FinancedTotal);
        }

        [TestMethod]
        public void Should_apply_remainder_gift_certificates_to_financed_amount()
        {
            var paydat = new PaymentData()
            {
                FinancedTotal = 1000,
                UpfrontTotal = 500,
                GiftCardAmount = 700,
            };
            paydat = DefaultContext.FinanceTask.ApplyGiftCertificate(paydat);

            var expectedFinanced = 800; // 800 or 300
            var expectedUpfront = 0; //0 or 500
            var expectedGift = 0;

            Assert.AreEqual(expectedGift, paydat.GiftCardAmount);
            Assert.AreEqual(expectedUpfront, paydat.UpfrontTotal);
            Assert.AreEqual(expectedFinanced, paydat.FinancedTotal);
        }

        [TestMethod]
        public void Should_retain_remaining_gift_certificate()
        {
            var paydat = new PaymentData()
            {
                FinancedTotal = 1000,
                UpfrontTotal = 500,
                GiftCardAmount = 2100,
            };
            paydat = DefaultContext.FinanceTask.ApplyGiftCertificate(paydat);

            var expectedFinanced = 0;
            var expectedUpfront = 0; //0 or 500
            var expectedGift = 600; //600 or 1100

            Assert.AreEqual(expectedGift, paydat.GiftCardAmount);
            Assert.AreEqual(expectedUpfront, paydat.UpfrontTotal);
            Assert.AreEqual(expectedFinanced, paydat.FinancedTotal);
        }

        [TestMethod]
        public void Should_apply_credit_to_down_payment()
        {
            var paydat = new PaymentData()
            {
                FinancedTotal = 1000,
                UpfrontTotal = 500,
                CreditAmount = 100,
            };
            paydat = DefaultContext.FinanceTask.ApplyCredit(paydat);

            var expectedFinanced = 1000;
            var expectedUpfront = 400;
            var expectedCredit = 0;

            Assert.AreEqual(expectedCredit, paydat.CreditAmount);
            Assert.AreEqual(expectedUpfront, paydat.UpfrontTotal);
            Assert.AreEqual(expectedFinanced, paydat.FinancedTotal);
        }

        [TestMethod]
        public void Should_apply_remaining_credit_to_Financed_amount()
        {
            var paydat = new PaymentData()
            {
                FinancedTotal = 1000,
                UpfrontTotal = 500,
                CreditAmount = 700,
            };
            paydat = DefaultContext.FinanceTask.ApplyCredit(paydat);

            var expectedFinanced = 800;
            var expectedUpfront = 0;
            var expectedCredit = 0;

            Assert.AreEqual(expectedCredit, paydat.CreditAmount);
            Assert.AreEqual(expectedUpfront, paydat.UpfrontTotal);
            Assert.AreEqual(expectedFinanced, paydat.FinancedTotal);
        }

        [TestMethod]
        public void Should_retain_remaining_credit()
        {
            var paydat = new PaymentData()
            {
                FinancedTotal = 1000,
                UpfrontTotal = 500,
                CreditAmount = 2100,
            };
            paydat = DefaultContext.FinanceTask.ApplyCredit(paydat);

            var expectedFinanced = 0;
            var expectedUpfront = 0;
            var expectedCredit = 600;

            Assert.AreEqual(expectedCredit, paydat.CreditAmount);
            Assert.AreEqual(expectedUpfront, paydat.UpfrontTotal);
            Assert.AreEqual(expectedFinanced, paydat.FinancedTotal);
        }
    }
}
