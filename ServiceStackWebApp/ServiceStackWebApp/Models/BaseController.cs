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
    public class BaseController : ServiceStackController<USession>
    {
       
    }
}