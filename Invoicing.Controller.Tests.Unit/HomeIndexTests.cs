using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using Invoicing.Model;
using Invoicing.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;


namespace Invoicing.Controller.Tests.Unit
{
    [TestClass]
    public class When_serving_the_invoice_calculation_page
    {
        private HomeController _controller = new HomeController(); 

        [TestMethod]
        public void Should_be_able_to_retrieve_an_invoice_entry_page()
        {
            const string expectedViewName = "";
            var result = _controller.Index() as ViewResult;
            Assert.IsNotNull(result, "Should have returned a ViewResult");
            Assert.AreEqual(expectedViewName, result.ViewName, "View name should have been empty", expectedViewName);
        }

        [TestMethod]
        public void Should_be_able_to_autocomplete_parts_data()
        {
            const string term = "ro";
            var result = _controller.GetPartsList(term);
            Assert.IsNotNull(result, "Should have returned a JSONResult");
        }
    }
}
