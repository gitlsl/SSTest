using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Funq;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.Logging;
using ServiceStack.Logging.NLogger;
using ServiceStack.Mvc;
using ServiceStack.OrmLite;
using ServiceStackWebApp.ServiceInterface;
using ServiceStackWebApp.ServiceModel;

namespace ServiceStackWebApp
{
    public class AppHost : AppHostBase
    {
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost()
            : base("ServiceStackWebApp", typeof(TestServices).Assembly) { }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            SetConfig(new HostConfig
            {
                HandlerFactoryPath = "api",
            });
            //Config examples
            //this.Plugins.Add(new PostmanFeature());
            //this.Plugins.Add(new CorsFeature());

            //Set MVC to use the same Funq IOC as ServiceStack
            ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));

            var path = "~/App_Data/db.sqlite".MapHostAbsolutePath();
            container.Register<IDbConnectionFactory>(c => new OrmLiteConnectionFactory(path, SqliteDialect.Provider));
            using (var db = container.Resolve<IDbConnectionFactory>().Open())
            {
                db.CreateTableIfNotExists<ShopItem>();
            }


            /*
                         private static readonly ILog Log = LogManager.GetLogger(typeof(OrmLiteWriteCommandExtensions));
                         不想 sql 日志输出的话 OrmLiteWriteCommandExtensions  这个对象 干掉
            */

            LogManager.LogFactory = new NLogFactory();
            ILog log = LogManager.GetLogger("xx");
            log.Debug("xx");
        }
    }
}