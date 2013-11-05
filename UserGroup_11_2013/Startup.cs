using System.Web.Http;
using Microsoft.Owin;
using Owin;
using UserGroup;

[assembly: OwinStartup(typeof(Startup))]
namespace UserGroup
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
