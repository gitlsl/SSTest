using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Funq;
using ServiceStack;
using ServiceStack.Api.Swagger;
using ServiceStack.Auth;
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
            LogManager.LogFactory = new NLogFactory();
            //Config examples
            //this.Plugins.Add(new PostmanFeature());
            //this.Plugins.Add(new CorsFeature());
            Plugins.Add(new AuthFeature(() => new UserSession(),
                    new IAuthProvider[]
                    {
                        new CredentialsAuthProvider(),

                    })
                {
                    HtmlRedirect = "~/",
                    IncludeRegistrationService = true,
                    MaxLoginAttempts = 5,
                }
            );
            Plugins.Add(new SwaggerFeature());


                var path = "~/App_Data/db.sqlite".MapHostAbsolutePath();
            container.Register<IDbConnectionFactory>(c => new OrmLiteConnectionFactory(path, SqliteDialect.Provider));
            container.Register<IUserAuthRepository>(c =>
               new OrmLiteAuthRepository(c.Resolve<IDbConnectionFactory>()));

            container.Resolve<IUserAuthRepository>().InitSchema();
            using (var db = container.Resolve<IDbConnectionFactory>().Open())
            {
                db.DropAndCreateTable<SoftInfo>();
                db.DropAndCreateTable<SoftKey>();
                db.DropAndCreateTable<UserInfo>();
            }
            /*
                private static readonly ILog Log = LogManager.GetLogger(typeof(OrmLiteWriteCommandExtensions));
                不想 sql 日志输出的话 OrmLiteWriteCommandExtensions  这个对象 干掉
            */


            //Set MVC to use the same Funq IOC as ServiceStack
            ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));

            container.Register<ILog>(c => LogManager.GetLogger("log"));

            ILog log = container.Resolve<ILog>();
            log.Debug("xx");
        }
    }
}