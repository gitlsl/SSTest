using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;

namespace ServiceStackWebApp.ServiceModel
{
    [Route("/Test")]
    [Route("/Test/{Name}")]
    public class Test : IReturn<TestResponse>
    {
        public string Name { get; set; }
    }

    public class TestResponse
    {
        public string Result { get; set; }
    }
}