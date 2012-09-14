using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace Invoicing.Tests.CodedUI
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class InvoiceEntryTests
    {
        [TestMethod]
        public void Should_be_able_to_add_an_item_to_invoice()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
            this.UIMap.LaunchSite();
            this.UIMap.SearchForPart();
            this.UIMap.ClickAddToOrder();
            this.UIMap.AssertAddedItem();
            this.UIMap.CloseBrowser();
        }

        [TestMethod]
        public void Should_be_able_to_calculate_a_payment_schedule()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
            this.UIMap.LaunchSite();
            this.UIMap.SearchForPart();
            this.UIMap.ClickAddToOrder();
            this.UIMap.AssertAddedItem();
            this.UIMap.EnterDiscount();
            this.UIMap.EnterQuantity();
            this.UIMap.EnterCredit();
            this.UIMap.EnterGiftCard();
            this.UIMap.EnterAPR();
            this.UIMap.EnterTerms();
            this.UIMap.ClickCalculate();
            this.UIMap.AssertAmountDue();
            this.UIMap.AssertMonthlyPayment();
            this.UIMap.AssertFinalPayment();
            this.UIMap.AssertGiftCardRemaining();
            this.UIMap.AssertCreditRemaining();
            this.UIMap.CloseBrowser();
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
