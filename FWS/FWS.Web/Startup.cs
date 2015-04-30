using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FWS.Web.Startup))]
namespace FWS.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //new StartUpProject().Initialize();
        }
    }
}
