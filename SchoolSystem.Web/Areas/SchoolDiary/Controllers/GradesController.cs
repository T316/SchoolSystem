using SchoolSystem.Services;
using SchoolSystem.Services.Interfaces;
using SchoolSystem.Web.Attritutes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolSystem.Web.Areas.SchoolDiary.Controllers
{
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
            return View(vms);
        }
    }
}