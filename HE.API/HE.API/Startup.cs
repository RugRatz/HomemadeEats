﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup("HE_ApiOwinConfig", typeof(HE.API.Startup))]

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
