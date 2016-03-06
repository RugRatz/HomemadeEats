using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HE.MVC.UserInterface.Startup))]
namespace HE.MVC.UserInterface
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
