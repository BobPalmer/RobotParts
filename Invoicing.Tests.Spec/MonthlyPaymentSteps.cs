using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Invoicing.Model;
using Invoicing.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Invoicing.Tests.Spec
{
    [Binding]
    public class MonthlyPaymentSteps
    {
        private PaymentData _payment;
        private PaymentSchedule _schedule;

        [Given(@"I have entered an APR of (.*)%")]
        public void GivenIHaveEnteredAnAPROf(Decimal apr)
        {
            _payment.APR = apr;
        }

        [Given(@"a financed amount of \$(.*)")]
        public void GivenAFinancedAmountOf(decimal financed)
        {
            _payment.FinancedTotal = financed;
        }

        [Given(@"terms of (.*) (months|years)")]
        public void GivenTermsOfMonthsOrYears(int terms, string unit)
        {
            if (unit == "years") terms *= 12;
            _payment.Terms = terms;
        }

        [When(@"I request a payment schedule")]
        public void WhenIRequestAPaymentSchedule()
        {
            var tasks = new FinanceTasks(null);
            _schedule = tasks.GeneratePaymentSchedule(_payment);
        }

        [Then(@"the monthly payment should be \$(.*)")]
        public void ThenTheMonthlyPaymentShouldBe(decimal monthly)
        {
            Assert.AreEqual(monthly, _schedule.MonthlyPayment);
        }

        [Then(@"the final payment should be \$(.*)")]
        public void ThenTheFinalPaymentShouldBe(decimal final)
        {
            Assert.AreEqual(final, _schedule.FinalPayment);
        }
    }
}
