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
    public class When_Calculating_a_Payment_Schedule
    {
        [ClassInitialize]
        public static void ClassSetup(TestContext TestContext)
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        [TestMethod]
        public void Should_be_able_to_determine_a_payment_schedule()
        {
            var paydata = new PaymentData
                              {
                                  APR = 7.8M,
                                  FinancedTotal = 225000M,
                                  Terms = 360,
                                  GiftCardAmount = 0M,
                                  CreditAmount = 0M,
                                  UpfrontTotal = 25000M
                              };
            var expectedAmountDue = 25000M;
            var expectedPayment = 1619.71M;
            var expectedFinal = 1619.22M;
            var expectedGift = 0M;
            var expectedCredit = 0M;

            var schedule = DefaultContext.FinanceTask.GeneratePaymentSchedule(paydata);

            Assert.AreEqual(expectedAmountDue, schedule.UpfrontDue);
            Assert.AreEqual(expectedPayment, schedule.MonthlyPayment);
            Assert.AreEqual(expectedFinal, schedule.FinalPayment);
            Assert.AreEqual(expectedGift, schedule.GiftCardBalance);
            Assert.AreEqual(expectedCredit, schedule.CreditBalance);
        }

        [TestMethod]
        public void Should_be_able_to_return_remaining_credits()
        {
            var paydata = new PaymentData
            {
                APR = 10M,
                FinancedTotal = 0,
                Terms = 12,
                GiftCardAmount = 100M,
                CreditAmount = 200M
            };
            var expectedAmountDue = 0M;
            var expectedPayment = 0M;
            var expectedFinal = 0M;
            var expectedGift = 100M;
            var expectedCredit = 200M;

            var schedule = DefaultContext.FinanceTask.GeneratePaymentSchedule(paydata);

            Assert.AreEqual(expectedAmountDue, schedule.UpfrontDue);
            Assert.AreEqual(expectedPayment, schedule.MonthlyPayment);
            Assert.AreEqual(expectedFinal, schedule.FinalPayment);
            Assert.AreEqual(expectedGift, schedule.GiftCardBalance);
            Assert.AreEqual(expectedCredit, schedule.CreditBalance);
        }
    }
}
