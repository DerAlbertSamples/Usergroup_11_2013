using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using UserGroup.Entities;

namespace UserGroup
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );


            SetupODataConventionsRoutes(config);
        }

        private static void SetupODataConventionsRoutes(HttpConfiguration config)
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Order>("Order");
            builder.EntitySet<Customer>("Customers");
            builder.EntitySet<Employee>("Employees");
            builder.EntitySet<OrderDetail>("OrderDetail");
            config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
        }
    }
}