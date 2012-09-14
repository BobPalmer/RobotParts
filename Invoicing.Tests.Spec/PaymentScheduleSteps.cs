using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Invoicing.Model;
using Invoicing.Tasks;
using Invoicing.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using Common.Extensions;
namespace Common.Extensions
{
    public static class StringExtensions
    {
        public static decimal ParseCurrency(this string str)
        {
            str = str.Replace("$","").Trim();
            decimal val;
            decimal.TryParse(str, out val);
            return val;
        }

        public static decimal ParsePercent(this string str)
        {
            str = str.Replace("%", "").Trim();
            decimal val;
            decimal.TryParse(str, out val);
            return val / 100;
        }

        public static int ParseInt(this string str)
        {
            int val;
            Int32.TryParse(str, out val);
            return val;
        }
    }
}


namespace Invoicing.Tests.Spec
{
    [Binding]
    public class PaymentScheduleSteps
    {
        [Given(@"an order with the following items")]
        public void GivenAnOrderWithTheFollowingItems(Table table)
        {
            var orderlines = new List<PartData>();
            foreach (var row in table.Rows)
            {
                var line = new PartData();
                line.PartName = row["Product"];
                line.UnitPrice = row["Price"].ParseCurrency();
                line.UpfrontPercent = row["Upfront %"].ParsePercent();
                line.DiscountPercent = row["Discount %"].ParsePercent();
                line.Quantity = row["Quantity"].ParseInt();
                orderlines.Add(line);
            }
            var order = (ScenarioContext.Current.Get<PaymentData>());
            order.Parts = orderlines.ToArray();
            ScenarioContext.Current.Set(order);
        }

        [Given(@"an order with a variety of items")]
        public void GivenAnOrderWithAVarietyOfItems()
        {
            //no action needed, the context was set up in our event hook
        }


        [Given(@"the following terms and balances")]
        public void GivenTheFollowingTermsAndBalances(Table table)
        {
            var row = table.Rows.First();
            var order = (ScenarioContext.Current.Get<PaymentData>());
            order.CreditAmount = row["Credit Balance"].ParseCurrency();
            order.GiftCardAmount = row["Gift Card Balance"].ParseCurrency();
            order.APR = row["APR %"].ParsePercent();
            order.Terms = row["Number of Payments"].ParseInt();
            ScenarioContext.Current.Set(order);
        }

        [When(@"I press calculate")]
        public void WhenIPressCalculate()
        {
            var tasks = (ScenarioContext.Current.Get<PaymentTasks>());
            var order = (ScenarioContext.Current.Get<PaymentData>());
            ScenarioContext.Current.Set(tasks.CalculatePaymentSchedule(order));
        }

        [Then(@"the resulting payment schedule should be")]
        public void ThenTheResultingPaymentScheduleShouldBe(Table table)
        {
            var row = table.Rows.First();
            var schedule = ScenarioContext.Current.Get<PaymentSchedule>();
            Assert.AreEqual(row["Down Payment"].ParseCurrency(), schedule.UpfrontDue);
            Assert.AreEqual(row["Monthly Payment"].ParseCurrency(), schedule.MonthlyPayment);
            Assert.AreEqual(row["Final Payment"].ParseCurrency(), schedule.FinalPayment);
            Assert.AreEqual(row["Gift Card"].ParseCurrency(), schedule.GiftCardBalance);
            Assert.AreEqual(row["Credit"].ParseCurrency(), schedule.CreditBalance);
        }
    }
}
