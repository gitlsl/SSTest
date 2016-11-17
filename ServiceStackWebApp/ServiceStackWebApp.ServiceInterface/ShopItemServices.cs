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
    public class ShopItemServices : Service
    {
        public object Any(NewShopItem request)
        {
            ILog log = LogManager.GetLogger("Service");
            log.Warn(request.Dump());
            

            var item  = request.ConvertTo<ShopItem>();

            item.CreateTime = DateTime.Now;
            Db.Insert(item);
            Db.Insert(item,true);
            return "xx";
        }
    }
}