using System;
using NUnit.Framework;
using ServiceStackWebApp.ServiceInterface;
using ServiceStackWebApp.ServiceModel;
using ServiceStack.Testing;
using ServiceStack;

namespace ServiceStackWebApp.Tests
{
    [TestFixture]
    public class UnitTests
    {
        private readonly ServiceStackHost appHost;

        public UnitTests()
        {
            appHost = new BasicAppHost(typeof(TestServices).Assembly)
            {
                ConfigureContainer = container =>
                {
                    //Add your IoC dependencies here
                }
            }
            .Init();
        }

        [TestFixtureTearDown]
        public void TestFixtureTearDown()
        {
            appHost.Dispose();
        }

        [Test]
        public void TestMethod1()
        {
            var service = appHost.Container.Resolve<TestServices>();

            var response = (TestResponse)service.Any(new Test { Name = "World" });

            Assert.That(response.Result, Is.EqualTo("Test, World!"));
        }
    }
}
