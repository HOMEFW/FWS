using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FWS.MVC.Startup))]
namespace FWS.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
