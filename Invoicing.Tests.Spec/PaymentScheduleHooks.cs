using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Invoicing.Model;
using Invoicing.Tasks;
using Invoicing.TestHelpers;
using TechTalk.SpecFlow;

namespace Invoicing.Tests.Spec
{
    [Binding]
    public class PaymentScheduleHooks
    {
        private static PaymentTasks _payTasks;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //Load up a few data bits for our scenarios
            var repo = new FakePartsRepository();
            _payTasks = new PaymentTasks(repo);
        }

        [BeforeScenario("customOrder")]
        public void BeforeScenario()
        {
            var order = new PaymentData();
            var schedule = new PaymentSchedule();
            ScenarioContext.Current.Set(order);
            ScenarioContext.Current.Set(schedule);
            ScenarioContext.Current.Set(_payTasks);
        }

        [BeforeScenario("LargeOrder")]
        public void BeforeLargeOrderScenario()
        {
            var order = new PaymentData();
            var schedule = new PaymentSchedule();

            var parts = new List<PartData>
                {
                    new PartData {PartName = "Flexible whisker sensors", UnitPrice = 100M, UpfrontPercent = 0M, DiscountPercent = .1M, Quantity = 100},
                    new PartData {PartName = "Assorted Gears and Bearings", UnitPrice = 50M, UpfrontPercent = 0M, DiscountPercent = 0M, Quantity = 100},
                    new PartData {PartName = "Mountable Halogen Floodlights", UnitPrice = 100M, UpfrontPercent = .1M, DiscountPercent = .05M, Quantity = 50}
                };
            order.Parts = parts.ToArray();
            ScenarioContext.Current.Set(order);
            ScenarioContext.Current.Set(schedule);
            ScenarioContext.Current.Set(_payTasks);
        }
    }
}
