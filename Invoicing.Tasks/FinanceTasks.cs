using System;
using System.Linq;
using Invoicing.Model;
using Invoicing.Repository;

namespace Invoicing.Tasks
{
    public class FinanceTasks
    {
        private IPartsRepository _partsRepo;

        public FinanceTasks(IPartsRepository partsRepo)
        {
            _partsRepo = partsRepo;
        }

        public PartData LoadLineData(PartData line)
        {
            var curline = line;
            var part = _partsRepo.GetPartByName(line.PartName);
            if (curline.UnitPrice == 0) curline.UnitPrice = part.UnitPrice;
            if (curline.UpfrontPercent == 0) curline.UpfrontPercent = part.UpfrontPercent;
            curline.DiscountPercent = curline.DiscountPercent / 100;
            return curline;
        }

        public PartData CalculateLineTotals(PartData line)
        {
            var curline = line;
            var extendedPrice = curline.UnitPrice * curline.Quantity;
            var totalDiscount = extendedPrice * curline.DiscountPercent;
            extendedPrice = extendedPrice - totalDiscount;
            curline.UpfrontAmount = extendedPrice * (curline.UpfrontPercent);
            curline.FinancedAmount = extendedPrice - curline.UpfrontAmount;
            return curline;
        }

        public PaymentData CombineLineData(PaymentData order)
        {
            var curorder = order;
            curorder.UpfrontTotal = curorder.Parts.Sum(x => x.UpfrontAmount);
            curorder.FinancedTotal = curorder.Parts.Sum(x => x.FinancedAmount);
            return curorder;
        }

        public PaymentData ApplyGiftCertificate(PaymentData order)
        {
            var curorder = order;
            decimal applyAmount;

            applyAmount = Math.Min(curorder.GiftCardAmount, curorder.UpfrontTotal);
            curorder.UpfrontTotal -= applyAmount;
            curorder.GiftCardAmount -= applyAmount;

            applyAmount = Math.Min(curorder.GiftCardAmount, curorder.FinancedTotal);
            curorder.FinancedTotal -= applyAmount;
            curorder.GiftCardAmount -= applyAmount;

            return curorder;
        }

        public PaymentData ApplyCredit(PaymentData order)
        {
            var curorder = order;
            decimal applyAmount;

            applyAmount = Math.Min(curorder.CreditAmount, curorder.UpfrontTotal);
            curorder.UpfrontTotal -= applyAmount;
            curorder.CreditAmount -= applyAmount;

            applyAmount = Math.Min(curorder.CreditAmount, curorder.FinancedTotal);
            curorder.FinancedTotal -= applyAmount;
            curorder.CreditAmount -= applyAmount;

            return curorder;
        }

        public PaymentSchedule GeneratePaymentSchedule(PaymentData order)
        {
            var sched = new PaymentSchedule();
            sched.CreditBalance = order.CreditAmount;
            sched.GiftCardBalance = order.GiftCardAmount;
            sched.UpfrontDue = order.UpfrontTotal;

            //Default in case rate is 0%
            var payment = (double)order.FinancedTotal / order.Terms;

            if (order.APR > 0)
            {
                var rate = (double)order.APR / 1200;
                payment = rate * (double)order.FinancedTotal / (1 - Math.Pow((1 + rate), (order.Terms * -1)));
            }

            var roundPayment = Math.Round(payment, 2);
            //Always round up!
            if (roundPayment < payment) roundPayment += .01;

            sched.MonthlyPayment = (Decimal)roundPayment;
            var totalDue = payment * order.Terms;
            var totalPayments = sched.MonthlyPayment * order.Terms;
            var finalAdjustment = (decimal)totalDue - totalPayments;
            sched.FinalPayment = sched.MonthlyPayment + Math.Round(finalAdjustment, 2);
            return sched;
        }
    }
}