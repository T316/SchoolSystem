﻿using System.Web.Mvc;

namespace SchoolSystem.Web.Areas.SchoolDiary
{
    public class SchoolDiaryAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SchoolDiary";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.Routes.MapMvcAttributeRoutes();
             
            context.MapRoute(
                "SchoolDiary_default",
                "SchoolDiary/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}