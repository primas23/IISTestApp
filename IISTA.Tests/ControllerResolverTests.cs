using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MSTestExtensions;

using IISTA.AssemblySearch;
using IISTA.Common.Contracts;
using IISTA.HttpRequest;
using IISTA.RazorViewsCustom;

namespace IISTA.Tests
{
    [TestClass]
    public class ControllerResolverTests
    {
        [TestMethod]
        public void ResolverShouldThrowExceptionWhenNoControllerNameIsGiven()
        {
            IHttpRequest httpRequest = new HttpRequestCustom()
            {
                Path = new Path()
            };

            ThrowsAssert.Throws<ArgumentNullException>(() => new ControllerResolver(httpRequest));
        }

        [TestMethod]
        public void ResolverShouldReturnHomePageViewWhenControllerNameIsHome()
        {
            IHttpRequest httpRequest = new HttpRequestCustom()
            {
                Path = new Path()
                {
                    ActionController = "home"
                }
            };

            Assert.IsInstanceOfType(new ControllerResolver(httpRequest).GetInstanceOfController, typeof(HomePageView));
        }

        [TestMethod]
        public void ResolverShouldReturnNullWhenControllerNameDoesNotMatch()
        {
            IHttpRequest httpRequest = new HttpRequestCustom()
            {
                Path = new Path()
                {
                    ActionController = "Asdasd"
                }
            };

            Assert.IsNull(new ControllerResolver(httpRequest).GetInstanceOfController);
        }

        [TestMethod]
        public void ResolverShouldReturnIRenderableWhenValidControllerNameIsGiven()
        {
            IHttpRequest httpRequest = new HttpRequestCustom()
            {
                Path = new Path()
                {
                    ActionController = "home"
                }
            };

            Assert.IsInstanceOfType(new ControllerResolver(httpRequest).GetInstanceOfController, typeof(IRenderable));
        }
    }
}
