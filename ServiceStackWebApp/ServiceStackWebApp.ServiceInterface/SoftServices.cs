using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using ServiceStack.Configuration;
using ServiceStack.Logging;
using ServiceStack.OrmLite;
using ServiceStack.Text;
using ServiceStackWebApp.ServiceModel;

namespace ServiceStackWebApp.ServiceInterface
{
    public class SoftServices : Service
    {
        public ILog Log { get; set; }
       
        public object Any(NewSoft request)
        {
            Log.Debug("haha");
            if (request.Name.IndexOf("q") > 0)
            {
                throw new Exception("qqq");
            }


            var item  = request.ConvertTo<SoftInfo>();
            item.Auther = "liu";
            item.Guid = Guid.NewGuid().ToString("N");
            item.Id = (int)Db.Insert(item, true);

            SoftKey key = new SoftKey()
            {
                Auther = item.Auther,
                KeyType = SoftKeyType.Year,
                KeyValue = 22,
                SoftGuid = item.Guid,
                Key = Guid.NewGuid().ToString("N")
        };
            Db.Insert(key);
            Response.AddHeader("result", "ok");

          
            return new NewSoftResponse()
            {
                Guid = item.Guid,
                Id = item.Id
            };
        }
    }
}