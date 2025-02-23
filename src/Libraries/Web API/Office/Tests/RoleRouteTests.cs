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

namespace MixERP.Net.Api.Office.Tests
{
    public class RoleRouteTests
    {
        [Theory]
        [InlineData("/api/{apiVersionNumber}/office/role/delete/{roleId}", "DELETE", typeof(RoleController), "Delete")]
        [InlineData("/api/office/role/delete/{roleId}", "DELETE", typeof(RoleController), "Delete")]
        [InlineData("/api/{apiVersionNumber}/office/role/edit/{roleId}", "PUT", typeof(RoleController), "Edit")]
        [InlineData("/api/office/role/edit/{roleId}", "PUT", typeof(RoleController), "Edit")]
        [InlineData("/api/{apiVersionNumber}/office/role/count-where", "POST", typeof(RoleController), "CountWhere")]
        [InlineData("/api/office/role/count-where", "POST", typeof(RoleController), "CountWhere")]
        [InlineData("/api/{apiVersionNumber}/office/role/get-where/{pageNumber}", "POST", typeof(RoleController), "GetWhere")]
        [InlineData("/api/office/role/get-where/{pageNumber}", "POST", typeof(RoleController), "GetWhere")]
        [InlineData("/api/{apiVersionNumber}/office/role/add-or-edit", "POST", typeof(RoleController), "AddOrEdit")]
        [InlineData("/api/office/role/add-or-edit", "POST", typeof(RoleController), "AddOrEdit")]
        [InlineData("/api/{apiVersionNumber}/office/role/add/{role}", "POST", typeof(RoleController), "Add")]
        [InlineData("/api/office/role/add/{role}", "POST", typeof(RoleController), "Add")]
        [InlineData("/api/{apiVersionNumber}/office/role/bulk-import", "POST", typeof(RoleController), "BulkImport")]
        [InlineData("/api/office/role/bulk-import", "POST", typeof(RoleController), "BulkImport")]
        [InlineData("/api/{apiVersionNumber}/office/role/meta", "GET", typeof(RoleController), "GetEntityView")]
        [InlineData("/api/office/role/meta", "GET", typeof(RoleController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/office/role/count", "GET", typeof(RoleController), "Count")]
        [InlineData("/api/office/role/count", "GET", typeof(RoleController), "Count")]
        [InlineData("/api/{apiVersionNumber}/office/role/all", "GET", typeof(RoleController), "GetAll")]
        [InlineData("/api/office/role/all", "GET", typeof(RoleController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/office/role/export", "GET", typeof(RoleController), "Export")]
        [InlineData("/api/office/role/export", "GET", typeof(RoleController), "Export")]
        [InlineData("/api/{apiVersionNumber}/office/role/1", "GET", typeof(RoleController), "Get")]
        [InlineData("/api/office/role/1", "GET", typeof(RoleController), "Get")]
        [InlineData("/api/{apiVersionNumber}/office/role/get?roleIds=1", "GET", typeof(RoleController), "Get")]
        [InlineData("/api/office/role/get?roleIds=1", "GET", typeof(RoleController), "Get")]
        [InlineData("/api/{apiVersionNumber}/office/role", "GET", typeof(RoleController), "GetPaginatedResult")]
        [InlineData("/api/office/role", "GET", typeof(RoleController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/office/role/page/1", "GET", typeof(RoleController), "GetPaginatedResult")]
        [InlineData("/api/office/role/page/1", "GET", typeof(RoleController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/office/role/count-filtered/{filterName}", "GET", typeof(RoleController), "CountFiltered")]
        [InlineData("/api/office/role/count-filtered/{filterName}", "GET", typeof(RoleController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/office/role/get-filtered/{pageNumber}/{filterName}", "GET", typeof(RoleController), "GetFiltered")]
        [InlineData("/api/office/role/get-filtered/{pageNumber}/{filterName}", "GET", typeof(RoleController), "GetFiltered")]

        [InlineData("/api/{apiVersionNumber}/office/role/custom-fields", "GET", typeof(RoleController), "GetCustomFields")]
        [InlineData("/api/office/role/custom-fields", "GET", typeof(RoleController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/office/role/custom-fields/{resourceId}", "GET", typeof(RoleController), "GetCustomFields")]
        [InlineData("/api/office/role/custom-fields/{resourceId}", "GET", typeof(RoleController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/office/role/meta", "HEAD", typeof(RoleController), "GetEntityView")]
        [InlineData("/api/office/role/meta", "HEAD", typeof(RoleController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/office/role/count", "HEAD", typeof(RoleController), "Count")]
        [InlineData("/api/office/role/count", "HEAD", typeof(RoleController), "Count")]
        [InlineData("/api/{apiVersionNumber}/office/role/all", "HEAD", typeof(RoleController), "GetAll")]
        [InlineData("/api/office/role/all", "HEAD", typeof(RoleController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/office/role/export", "HEAD", typeof(RoleController), "Export")]
        [InlineData("/api/office/role/export", "HEAD", typeof(RoleController), "Export")]
        [InlineData("/api/{apiVersionNumber}/office/role/1", "HEAD", typeof(RoleController), "Get")]
        [InlineData("/api/office/role/1", "HEAD", typeof(RoleController), "Get")]
        [InlineData("/api/{apiVersionNumber}/office/role/get?roleIds=1", "HEAD", typeof(RoleController), "Get")]
        [InlineData("/api/office/role/get?roleIds=1", "HEAD", typeof(RoleController), "Get")]
        [InlineData("/api/{apiVersionNumber}/office/role", "HEAD", typeof(RoleController), "GetPaginatedResult")]
        [InlineData("/api/office/role", "HEAD", typeof(RoleController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/office/role/page/1", "HEAD", typeof(RoleController), "GetPaginatedResult")]
        [InlineData("/api/office/role/page/1", "HEAD", typeof(RoleController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/office/role/count-filtered/{filterName}", "HEAD", typeof(RoleController), "CountFiltered")]
        [InlineData("/api/office/role/count-filtered/{filterName}", "HEAD", typeof(RoleController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/office/role/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(RoleController), "GetFiltered")]
        [InlineData("/api/office/role/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(RoleController), "GetFiltered")]

        [InlineData("/api/{apiVersionNumber}/office/role/custom-fields", "HEAD", typeof(RoleController), "GetCustomFields")]
        [InlineData("/api/office/role/custom-fields", "HEAD", typeof(RoleController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/office/role/custom-fields/{resourceId}", "HEAD", typeof(RoleController), "GetCustomFields")]
        [InlineData("/api/office/role/custom-fields/{resourceId}", "HEAD", typeof(RoleController), "GetCustomFields")]

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

        public RoleRouteTests()
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