using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HE.API.Startup))]

namespace HE.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
