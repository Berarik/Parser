using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_ParserTestApps.Startup))]
namespace MVC_ParserTestApps
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
