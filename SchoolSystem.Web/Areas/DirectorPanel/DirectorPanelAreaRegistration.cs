namespace SchoolSystem.Web.Areas.DirectorPanel
{
    using System.Web.Mvc;

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