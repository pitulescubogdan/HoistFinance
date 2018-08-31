using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;

namespace HoistFinance.Tests.UnitTests
{
    [TestClass]
    public class RoutingTests
    {
        [TestMethod]
        public void InsertData_RoutingPath_Returns_Ok()
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);

            var request = new HttpRequestMessage(new HttpMethod("GET"), @"http://localhost:58786/api/data");
            config.EnsureInitialized();
            var routeDataCollection = config.Routes.GetRouteData(request);
            var routeData = routeDataCollection.Values["MS_SubRoutes"] as IHttpRouteData[];
            var route = routeData[0].Route;

            //Assert
            Assert.IsNotNull(routeDataCollection);
            Assert.AreEqual("api/data", route.RouteTemplate);
        }

        [TestMethod]
        public void SaveFiles_RoutingPath_Returns_Ok()
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);

            var request = new HttpRequestMessage(new HttpMethod("GET"), @"http://localhost:58786/api/jobs/saveFiles");
            config.EnsureInitialized();
            //request.Content = new StringContent("[{\"Index\": 0,\"Name\": \"string\",\"Visits\": 0,\"Date\": \"2018-08-31T06:58:41.612Z\"}]", Encoding.UTF8, "application/json");
            //Act
            var routeDataCollection = config.Routes.GetRouteData(request);
            var routeData = routeDataCollection.Values["MS_SubRoutes"] as IHttpRouteData[];
            var route = routeData[0].Route;

            //Assert
            Assert.IsNotNull(routeDataCollection);
            Assert.AreEqual("api/jobs/saveFiles", route.RouteTemplate);
        }
    }
}
