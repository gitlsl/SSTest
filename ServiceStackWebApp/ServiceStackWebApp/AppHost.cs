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
            Plugins.Add(new AuthFeature(() => new USession(),
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
            container.Register<IHashProvider>(c => new NoEncryptHash());
          
            HashProviderTest(container);
        }

        private static void HashProviderTest(Container container)
        {
            ILog log = container.Resolve<ILog>();
            IHashProvider hash = container.Resolve<IHashProvider>();
            log.Debug(hash.VerifyHash("123sdsd".ToUtf8Bytes(), "123sdsd".ToUtf8Bytes(), null));
            log.Debug(hash.VerifyHashString("123", "123", null));
            log.Debug(hash.VerifyHash("123sdsd".ToUtf8Bytes(), "123sdsd1".ToUtf8Bytes(), null));
            log.Debug(hash.VerifyHashString("123", "1231", null));
            log.Debug(hash.VerifyHash(null, null, null));
            log.Debug(hash.VerifyHashString(null, null, null));
        }
    }

    public class NoEncryptHash : IHashProvider
    {
        private static byte[] x = new byte[] { };
        public void GetHashAndSalt(byte[] Data, out byte[] Hash, out byte[] Salt)
        {
            Hash = Data;
            Salt = x;
        }

        public void GetHashAndSaltString(string Data, out string Hash, out string Salt)
        {
            Hash = Data;
            Salt = null;
        }

        public bool VerifyHash(byte[] Data, byte[] Hash, byte[] Salt)
        {
            if (Data == null)
            {
                Data = x;
            }
            if (Hash == null)
            {
                Hash = x;
            }

            if (Data.Length != Hash.Length) return false;
            for (int Lp = 0; Lp < Data.Length; Lp++)
            {
                if (!Data[Lp].Equals(Hash[Lp]))
                    return false;
            }
            return true;
        }

        public bool VerifyHashString(string Data, string Hash, string Salt)
        {
            return Data == Hash;
        }
    }
}