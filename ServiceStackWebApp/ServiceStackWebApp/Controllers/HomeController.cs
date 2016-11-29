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
    public class HomeController : ServiceStackController
    {
        private ILog log = LogManager.GetLogger("HomeController");
        public ActionResult Index()
        {
            log.Debug("come in  HomeController");
          
            // service.Any(null);
            var sessionKey = SessionFeature.GetSessionKey();
            if (sessionKey == null)
            {
                log.Debug("it is first time");
               
            }


            var userSession = SessionFeature.GetOrCreateSession<UserSession>();
            // or SessionFeature.GetOrCreateSession<CustomUserSession>(CacheClient); 
            log.Debug(userSession.Address);
            // modifying User Session
            userSession.Address = "USA";

            // saving User Session
            var setResult = Cache.Set<UserSession>(SessionFeature.GetSessionKey(userSession.Id), userSession);
            log.Debug("cache set:"+ setResult);
            // Cache.CacheSet(sessionKey, userSession, TimeSpan.FromDays(22));

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