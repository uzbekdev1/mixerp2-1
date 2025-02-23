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
    public class WorkCenterRouteTests
    {
        [Theory]
        [InlineData("/api/{apiVersionNumber}/office/work-center/delete/{workCenterId}", "DELETE", typeof(WorkCenterController), "Delete")]
        [InlineData("/api/office/work-center/delete/{workCenterId}", "DELETE", typeof(WorkCenterController), "Delete")]
        [InlineData("/api/{apiVersionNumber}/office/work-center/edit/{workCenterId}", "PUT", typeof(WorkCenterController), "Edit")]
        [InlineData("/api/office/work-center/edit/{workCenterId}", "PUT", typeof(WorkCenterController), "Edit")]
        [InlineData("/api/{apiVersionNumber}/office/work-center/count-where", "POST", typeof(WorkCenterController), "CountWhere")]
        [InlineData("/api/office/work-center/count-where", "POST", typeof(WorkCenterController), "CountWhere")]
        [InlineData("/api/{apiVersionNumber}/office/work-center/get-where/{pageNumber}", "POST", typeof(WorkCenterController), "GetWhere")]
        [InlineData("/api/office/work-center/get-where/{pageNumber}", "POST", typeof(WorkCenterController), "GetWhere")]
        [InlineData("/api/{apiVersionNumber}/office/work-center/add-or-edit", "POST", typeof(WorkCenterController), "AddOrEdit")]
        [InlineData("/api/office/work-center/add-or-edit", "POST", typeof(WorkCenterController), "AddOrEdit")]
        [InlineData("/api/{apiVersionNumber}/office/work-center/add/{workCenter}", "POST", typeof(WorkCenterController), "Add")]
        [InlineData("/api/office/work-center/add/{workCenter}", "POST", typeof(WorkCenterController), "Add")]
        [InlineData("/api/{apiVersionNumber}/office/work-center/bulk-import", "POST", typeof(WorkCenterController), "BulkImport")]
        [InlineData("/api/office/work-center/bulk-import", "POST", typeof(WorkCenterController), "BulkImport")]
        [InlineData("/api/{apiVersionNumber}/office/work-center/meta", "GET", typeof(WorkCenterController), "GetEntityView")]
        [InlineData("/api/office/work-center/meta", "GET", typeof(WorkCenterController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/office/work-center/count", "GET", typeof(WorkCenterController), "Count")]
        [InlineData("/api/office/work-center/count", "GET", typeof(WorkCenterController), "Count")]
        [InlineData("/api/{apiVersionNumber}/office/work-center/all", "GET", typeof(WorkCenterController), "GetAll")]
        [InlineData("/api/office/work-center/all", "GET", typeof(WorkCenterController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/office/work-center/export", "GET", typeof(WorkCenterController), "Export")]
        [InlineData("/api/office/work-center/export", "GET", typeof(WorkCenterController), "Export")]
        [InlineData("/api/{apiVersionNumber}/office/work-center/1", "GET", typeof(WorkCenterController), "Get")]
        [InlineData("/api/office/work-center/1", "GET", typeof(WorkCenterController), "Get")]
        [InlineData("/api/{apiVersionNumber}/office/work-center/get?workCenterIds=1", "GET", typeof(WorkCenterController), "Get")]
        [InlineData("/api/office/work-center/get?workCenterIds=1", "GET", typeof(WorkCenterController), "Get")]
        [InlineData("/api/{apiVersionNumber}/office/work-center", "GET", typeof(WorkCenterController), "GetPaginatedResult")]
        [InlineData("/api/office/work-center", "GET", typeof(WorkCenterController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/office/work-center/page/1", "GET", typeof(WorkCenterController), "GetPaginatedResult")]
        [InlineData("/api/office/work-center/page/1", "GET", typeof(WorkCenterController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/office/work-center/count-filtered/{filterName}", "GET", typeof(WorkCenterController), "CountFiltered")]
        [InlineData("/api/office/work-center/count-filtered/{filterName}", "GET", typeof(WorkCenterController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/office/work-center/get-filtered/{pageNumber}/{filterName}", "GET", typeof(WorkCenterController), "GetFiltered")]
        [InlineData("/api/office/work-center/get-filtered/{pageNumber}/{filterName}", "GET", typeof(WorkCenterController), "GetFiltered")]

        [InlineData("/api/{apiVersionNumber}/office/work-center/custom-fields", "GET", typeof(WorkCenterController), "GetCustomFields")]
        [InlineData("/api/office/work-center/custom-fields", "GET", typeof(WorkCenterController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/office/work-center/custom-fields/{resourceId}", "GET", typeof(WorkCenterController), "GetCustomFields")]
        [InlineData("/api/office/work-center/custom-fields/{resourceId}", "GET", typeof(WorkCenterController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/office/work-center/meta", "HEAD", typeof(WorkCenterController), "GetEntityView")]
        [InlineData("/api/office/work-center/meta", "HEAD", typeof(WorkCenterController), "GetEntityView")]
        [InlineData("/api/{apiVersionNumber}/office/work-center/count", "HEAD", typeof(WorkCenterController), "Count")]
        [InlineData("/api/office/work-center/count", "HEAD", typeof(WorkCenterController), "Count")]
        [InlineData("/api/{apiVersionNumber}/office/work-center/all", "HEAD", typeof(WorkCenterController), "GetAll")]
        [InlineData("/api/office/work-center/all", "HEAD", typeof(WorkCenterController), "GetAll")]
        [InlineData("/api/{apiVersionNumber}/office/work-center/export", "HEAD", typeof(WorkCenterController), "Export")]
        [InlineData("/api/office/work-center/export", "HEAD", typeof(WorkCenterController), "Export")]
        [InlineData("/api/{apiVersionNumber}/office/work-center/1", "HEAD", typeof(WorkCenterController), "Get")]
        [InlineData("/api/office/work-center/1", "HEAD", typeof(WorkCenterController), "Get")]
        [InlineData("/api/{apiVersionNumber}/office/work-center/get?workCenterIds=1", "HEAD", typeof(WorkCenterController), "Get")]
        [InlineData("/api/office/work-center/get?workCenterIds=1", "HEAD", typeof(WorkCenterController), "Get")]
        [InlineData("/api/{apiVersionNumber}/office/work-center", "HEAD", typeof(WorkCenterController), "GetPaginatedResult")]
        [InlineData("/api/office/work-center", "HEAD", typeof(WorkCenterController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/office/work-center/page/1", "HEAD", typeof(WorkCenterController), "GetPaginatedResult")]
        [InlineData("/api/office/work-center/page/1", "HEAD", typeof(WorkCenterController), "GetPaginatedResult")]
        [InlineData("/api/{apiVersionNumber}/office/work-center/count-filtered/{filterName}", "HEAD", typeof(WorkCenterController), "CountFiltered")]
        [InlineData("/api/office/work-center/count-filtered/{filterName}", "HEAD", typeof(WorkCenterController), "CountFiltered")]
        [InlineData("/api/{apiVersionNumber}/office/work-center/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(WorkCenterController), "GetFiltered")]
        [InlineData("/api/office/work-center/get-filtered/{pageNumber}/{filterName}", "HEAD", typeof(WorkCenterController), "GetFiltered")]

        [InlineData("/api/{apiVersionNumber}/office/work-center/custom-fields", "HEAD", typeof(WorkCenterController), "GetCustomFields")]
        [InlineData("/api/office/work-center/custom-fields", "HEAD", typeof(WorkCenterController), "GetCustomFields")]
        [InlineData("/api/{apiVersionNumber}/office/work-center/custom-fields/{resourceId}", "HEAD", typeof(WorkCenterController), "GetCustomFields")]
        [InlineData("/api/office/work-center/custom-fields/{resourceId}", "HEAD", typeof(WorkCenterController), "GetCustomFields")]

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

        public WorkCenterRouteTests()
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