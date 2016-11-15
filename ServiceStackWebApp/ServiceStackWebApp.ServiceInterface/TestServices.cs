using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using ServiceStackWebApp.ServiceModel;

namespace ServiceStackWebApp.ServiceInterface
{
    public class TestServices : Service
    {
        public object Any(Test request)
        {
            return new TestResponse { Result = "Test, {0}!".Fmt(request.Name) };
        }
    }
}