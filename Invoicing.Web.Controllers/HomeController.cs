using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Invoicing.Model;
using Invoicing.Tasks;
using Invoicing.Web.Models;
using Ninject;

namespace Invoicing.Web.Controllers
{
    public class HomeController : Controller
    {
        private IKernel _kernel = new StandardKernel();
        private PartsTasks _parts;
        private PaymentTasks _pay;

        public HomeController()
        {
            _kernel.Load("Modules.*.dll");
            _parts = _kernel.Get<PartsTasks>(); 
            _pay = _kernel.Get<PaymentTasks>();
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetPartsList(string term)
        {
            var parts = _parts.SearchParts(term);
            var result = parts.Select(x => new {value = x.PartName, id = x.PartId});
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult CalcPaymentSchedule(PaymentData data)
        {
            var schedule = _pay.CalculatePaymentSchedule(data);
            var result = new
                             {
                                 AmountDue = String.Format("{0:C}",schedule.UpfrontDue),
                                 Payment = String.Format("{0:C}",schedule.MonthlyPayment),
                                 Final = String.Format("{0:C}",schedule.FinalPayment),
                                 Gift =String.Format("{0:C}",schedule.GiftCardBalance),
                                 Credit = String.Format("{0:C}",schedule.CreditBalance),
                             };
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        public string GetLineItem(string name)
        {
            var part = _parts.GetPartByName(name);
            var html = "";
            if (part != null)
            {
                var model = new LineItem(part);
                html =  RenderPartialViewToString("_LineItem", model);
            }
            return html;
        }

        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }

    }
}
