using System;
using Invoicing.Persistance;
using Invoicing.Repository;
using Invoicing.Tasks;
using Invoicing.TestHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Invoicing.Tests.Unit
{
    [TestClass]
    public class When_retrieving_available_items 
    {
        [ClassInitialize]
        public static void ClassSetup(TestContext TestContext)
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        [TestMethod]
        public void Should_be_able_to_retrieve_a_list_by_partial_name()
        {
            var expected =2;
            var term = "ro";
            var resultList = DefaultContext.PartsTask.SearchParts(term);
            Assert.AreEqual(expected, resultList.Count);
        }

        [TestMethod]
        public void Should_retrieve_no_more_than_a_specified_number_of_results()
        {
            var expected = 20;
            var term = "";
            var resultList = DefaultContext.PartsTask.SearchParts(term);
            Assert.AreEqual(expected, resultList.Count);
        }

        [TestMethod] 
        public void Should_be_able_to_retrieve_a_part_by_id()
        {
            var id = 32769;
            var part = DefaultContext.PartsTask.GetPartById(id);
            Assert.AreEqual(id,part.PartId);
        }

        [TestMethod]
        public void Should_be_able_to_retrieve_a_part_by_name()
        {
            var name = "Basic Microcontroller";
            var part = DefaultContext.PartsTask.GetPartByName(name);
            Assert.AreEqual(name, part.PartName);
        }
    }
}
