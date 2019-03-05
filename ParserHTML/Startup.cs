using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ParserHTML.Startup))]
namespace ParserHTML
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
