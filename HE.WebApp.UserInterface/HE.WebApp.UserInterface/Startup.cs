using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute("HE_WebApp_UserInterfaceConfig", typeof(HE.WebApp.UserInterface.Startup))]
namespace HE.WebApp.UserInterface
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
