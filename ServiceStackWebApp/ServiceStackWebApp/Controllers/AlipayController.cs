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
    public class AlipayController : BaseController
    {
        public ILog log = LogManager.GetLogger("AlipayController");
        public ActionResult Index()
        {
            log.Debug("come in  AlipayController");
        
       
          
            return new ContentResult() { Content ="asdas"};
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