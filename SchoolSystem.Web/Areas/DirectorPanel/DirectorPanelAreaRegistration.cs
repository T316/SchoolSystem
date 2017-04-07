using Ninject;
using SchoolSystem.Services;
using SchoolSystem.Services.Interfaces;
using System.Web.Mvc;
using System.Web.Routing;

namespace SchoolSystem.Web.Areas.DirectorPanel
{
    public class DirectorPanelAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "DirectorPanel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.Routes.MapMvcAttributeRoutes();

            context.MapRoute(
                "DirectorPanel_default",
                "DirectorPanel/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}