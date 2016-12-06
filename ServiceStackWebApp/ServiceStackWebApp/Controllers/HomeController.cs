using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceStack;
using ServiceStack.Logging;
using ServiceStack.Mvc;
using ServiceStackWebApp.ServiceInterface;

namespace ServiceStackWebApp.Controllers
{
    public class HomeController : BaseController
    {
        private ILog log = LogManager.GetLogger("HomeController");
        public ActionResult Index()
        {
            log.Debug("come in  HomeController");
        
      
          
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