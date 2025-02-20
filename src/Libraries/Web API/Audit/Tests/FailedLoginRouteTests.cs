// ReSharper disable All
using System;
using System.Configuration;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.Caching;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using Xunit;

namespace MixERP.Net.Api.Audit.Tests
{
    public class FailedLoginRouteTests
    {
        [Theory]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login/delete/{failedLoginId}", "DELETE", typeof(FailedLoginController), "Delete")]
        [InlineData("/api/audit/failed-login/delete/{failedLoginId}", "DELETE", typeof(FailedLoginController), "Delete")]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login/edit/{failedLoginId}", "PUT", typeof(FailedLoginController), "Edit")]
        [InlineData("/api/audit/failed-login/edit/{failedLoginId}", "PUT", typeof(FailedLoginController), "Edit")]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login/count-where", "POST", typeof(FailedLoginController), "CountWhere")]
        [InlineData("/api/audit/failed-login/count-where", "POST", typeof(FailedLoginController), "CountWhere")]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login/get-where/{pageNumber}", "POST", typeof(FailedLoginController), "GetWhere")]
        [InlineData("/api/audit/failed-login/get-where/{pageNumber}", "POST", typeof(FailedLoginController), "GetWhere")]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login/add-or-edit", "POST", typeof(FailedLoginController), "AddOrEdit")]
        [InlineData("/api/audit/failed-login/add-or-edit", "POST", typeof(FailedLoginController), "AddOrEdit")]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login/add/{failedLogin}", "POST", typeof(FailedLoginController), "Add")]
        [InlineData("/api/audit/failed-login/add/{failedLogin}", "POST", typeof(FailedLoginController), "Add")]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login/bulk-import", "POST", typeof(FailedLoginController), "BulkImport")]
        [InlineData("/api/audit/failed-login/bulk-import", "POST", typeof(FailedLoginController), "BulkImport")]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login/meta", "GET", typeof(FailedLoginController), "GetEntityView")]
        [InlineData("/api/audit/failed-login/meta", "GET", typeof(FailedLoginController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login/count", "GET", typeof(FailedLoginController), "Count")]
        [InlineData("/api/audit/failed-login/count", "GET", typeof(FailedLoginController), "Count")]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login/all", "GET", typeof(FailedLoginController), "GetAll")]
        [InlineData("/api/audit/failed-login/all", "GET", typeof(FailedLoginController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login/export", "GET", typeof(FailedLoginController), "Export")]
        [InlineData("/api/audit/failed-login/export", "GET", typeof(FailedLoginController), "Export")]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login/1", "GET", typeof(FailedLoginController), "Get")]
        [InlineData("/api/audit/failed-login/1", "GET", typeof(FailedLoginController), "Get")]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login/get?failedLoginIds=1", "GET", typeof(FailedLoginController), "Get")]
        [InlineData("/api/audit/failed-login/get?failedLoginIds=1", "GET", typeof(FailedLoginController), "Get")]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login", "GET", typeof(FailedLoginController), "GetPaginatedResult")]
        [InlineData("/api/audit/failed-login", "GET", typeof(FailedLoginController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login/page/1", "GET", typeof(FailedLoginController), "GetPaginatedResult")]
        [InlineData("/api/audit/failed-login/page/1", "GET", typeof(FailedLoginController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login/count-filtered/{filterName}", "GET", typeof(FailedLoginController), "CountFiltered")]
        [InlineData("/api/audit/failed-login/count-filtered/{filterName}", "GET", typeof(FailedLoginController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login/get-filtered/{pageNumber}/{filterName}", "GET", typeof(FailedLoginController), "GetFiltered")]
        [InlineData("/api/audit/failed-login/get-filtered/{pageNumber}/{filterName}", "GET", typeof(FailedLoginController), "GetFiltered")]

        [InlineData("/api/{apiVersionNumber}/audit/failed-login/custom-fields", "GET", typeof(FailedLoginController), "GetCustomFields")]
        [InlineData("/api/audit/failed-login/custom-fields", "GET", typeof(FailedLoginController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login/custom-fields/{resourceId}", "GET", typeof(FailedLoginController), "GetCustomFields")]
        [InlineData("/api/audit/failed-login/custom-fields/{resourceId}", "GET", typeof(FailedLoginController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login/meta", "HEAD", typeof(FailedLoginController), "GetEntityView")]
        [InlineData("/api/audit/failed-login/meta", "HEAD", typeof(FailedLoginController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login/count", "HEAD", typeof(FailedLoginController), "Count")]
        [InlineData("/api/audit/failed-login/count", "HEAD", typeof(FailedLoginController), "Count")]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login/all", "HEAD", typeof(FailedLoginController), "GetAll")]
        [InlineData("/api/audit/failed-login/all", "HEAD", typeof(FailedLoginController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login/export", "HEAD", typeof(FailedLoginController), "Export")]
        [InlineData("/api/audit/failed-login/export", "HEAD", typeof(FailedLoginController), "Export")]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login/1", "HEAD", typeof(FailedLoginController), "Get")]
        [InlineData("/api/audit/failed-login/1", "HEAD", typeof(FailedLoginController), "Get")]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login/get?failedLoginIds=1", "HEAD", typeof(FailedLoginController), "Get")]
        [InlineData("/api/audit/failed-login/get?failedLoginIds=1", "HEAD", typeof(FailedLoginController), "Get")]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login", "HEAD", typeof(FailedLoginController), "GetPaginatedResult")]
        [InlineData("/api/audit/failed-login", "HEAD", typeof(FailedLoginController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login/page/1", "HEAD", typeof(FailedLoginController), "GetPaginatedResult")]
        [InlineData("/api/audit/failed-login/page/1", "HEAD", typeof(FailedLoginController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login/count-filtered/{filterName}", "HEAD", typeof(FailedLoginController), "CountFiltered")]
        [InlineData("/api/audit/failed-login/count-filtered/{filterName}", "HEAD", typeof(FailedLoginController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(FailedLoginController), "GetFiltered")]
        [InlineData("/api/audit/failed-login/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(FailedLoginController), "GetFiltered")]

        [InlineData("/api/{apiVersionNumber}/audit/failed-login/custom-fields", "HEAD", typeof(FailedLoginController), "GetCustomFields")]
        [InlineData("/api/audit/failed-login/custom-fields", "HEAD", typeof(FailedLoginController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/audit/failed-login/custom-fields/{resourceId}", "HEAD", typeof(FailedLoginController), "GetCustomFields")]
        [InlineData("/api/audit/failed-login/custom-fields/{resourceId}", "HEAD", typeof(FailedLoginController), "GetCustomFields")]

        [Conditional("Debug")]
        public void TestRoute(string url, string verb, Type type, string actionName)
        {
            //Arrange
            url = url.Replace("{apiVersionNumber}", this.ApiVersionNumber);
            url = Host + url;

            //Act
            HttpRequestMessage request = new HttpRequestMessage(new HttpMethod(verb), url);

            IHttpControllerSelector controller = this.GetControllerSelector();
            IHttpActionSelector action = this.GetActionSelector();

            IHttpRouteData route = this.Config.Routes.GetRouteData(request);
            request.Properties[HttpPropertyKeys.HttpRouteDataKey] = route;
            request.Properties[HttpPropertyKeys.HttpConfigurationKey] = this.Config;

            HttpControllerDescriptor controllerDescriptor = controller.SelectController(request);

            HttpControllerContext context = new HttpControllerContext(this.Config, route, request)
            {
                ControllerDescriptor = controllerDescriptor
            };

            var actionDescriptor = action.SelectAction(context);

            //Assert
            Assert.NotNull(controllerDescriptor);
            Assert.NotNull(actionDescriptor);
            Assert.Equal(type, controllerDescriptor.ControllerType);
            Assert.Equal(actionName, actionDescriptor.ActionName);
        }

        #region Fixture
        private readonly HttpConfiguration Config;
        private readonly string Host;
        private readonly string ApiVersionNumber;

        public FailedLoginRouteTests()
        {
            this.Host = ConfigurationManager.AppSettings["HostPrefix"];
            this.ApiVersionNumber = ConfigurationManager.AppSettings["ApiVersionNumber"];
            this.Config = GetConfig();
        }

        private HttpConfiguration GetConfig()
        {
            if (MemoryCache.Default["Config"] == null)
            {
                HttpConfiguration config = new HttpConfiguration();
                config.MapHttpAttributeRoutes();
                config.Routes.MapHttpRoute("VersionedApi", "api/" + this.ApiVersionNumber + "/{schema}/{controller}/{action}/{id}", new { id = RouteParameter.Optional });
                config.Routes.MapHttpRoute("DefaultApi", "api/{schema}/{controller}/{action}/{id}", new { id = RouteParameter.Optional });

                config.EnsureInitialized();
                MemoryCache.Default["Config"] = config;
                return config;
            }

            return MemoryCache.Default["Config"] as HttpConfiguration;
        }

        private IHttpControllerSelector GetControllerSelector()
        {
            if (MemoryCache.Default["ControllerSelector"] == null)
            {
                IHttpControllerSelector selector = this.Config.Services.GetHttpControllerSelector();
                return selector;
            }

            return MemoryCache.Default["ControllerSelector"] as IHttpControllerSelector;
        }

        private IHttpActionSelector GetActionSelector()
        {
            if (MemoryCache.Default["ActionSelector"] == null)
            {
                IHttpActionSelector selector = this.Config.Services.GetActionSelector();
                return selector;
            }

            return MemoryCache.Default["ActionSelector"] as IHttpActionSelector;
        }
        #endregion
    }
}