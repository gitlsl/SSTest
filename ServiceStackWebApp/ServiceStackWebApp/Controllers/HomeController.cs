using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceStack.Logging;
using ServiceStack.Mvc;

namespace ServiceStackWebApp.Controllers
{
    public class HomeController : ServiceStackController
    {
        private ILog log = LogManager.GetLogger("HomeController");
        public ActionResult Index()
        {
            log.Debug("xq hlog");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}