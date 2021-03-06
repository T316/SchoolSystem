﻿namespace SchoolSystem.Web.Areas.SchoolDiary.Controllers
{
    using SchoolSystem.Services.Interfaces.SchoolDiary;
    using SchoolSystem.Web.Attritutes;
    using System.Web.Mvc;

    [MyAuthorize]
    [RouteArea("SchoolDiary")]
    public class GradesController : Controller
    {
        private IGradesService service;

        public GradesController(IGradesService service)
        {
            this.service = service;
        }

        [Route("Grades")]
        public ActionResult All()
        {
            var vms = this.service.GetAllGrades();
            return this.View(vms);
        }
    }
}