using System.Web.Mvc;

namespace MVC_ParserTestApps.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                name: "Admin",
                url: "admin/{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"MVC_ParserTestApps.Areas.Admin.Controllers"}
            );
        }
    }
}