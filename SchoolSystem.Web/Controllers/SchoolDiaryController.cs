using SchoolSystem.Services;
using SchoolSystem.Services.Interfaces;
using SchoolSystem.Web.Attritutes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolSystem.Web.Controllers
{
    [MyAuthorize]
    [RoutePrefix("SchoolDiary")]
    public class SchoolDiaryController : Controller
    {
        private ISchoolDiaryService service;

        public SchoolDiaryController(ISchoolDiaryService service)
        {
            this.service = service;
        }

        [Route]
        [Route("Grades")]
        public ActionResult Grades()
        {
            var vms = this.service.GetAllGrades();
            return View(vms);
        }

        [Route("Subjects/{id}")]
        public ActionResult Subjects(int id)
        {
            var vms = this.service.GetAllSubjectsForGrade(id);
            return View(vms);
        }

        [Route("Students/{id}")]
        public ActionResult Students(int id)
        {
            var vms = this.service.GetAllStudentsForGrade(id);
            return View(vms);
        }
    }
}