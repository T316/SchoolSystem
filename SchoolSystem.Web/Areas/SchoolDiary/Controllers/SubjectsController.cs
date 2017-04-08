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
    public class SubjectsController : Controller
    {
        private ISubjectsService service;

        public SubjectsController(ISubjectsService service)
        {
            this.service = service;
        }

        [Route("Grade/{id}/Subjects")]
        public ActionResult All(int id)
        {
            var vms = this.service.GetAllSubjectsForGrade(id);
            return View(vms);
        }

        [Route("Subject/{id}")]
        public ActionResult SubjectDetails(int id)
        {
            var vm = this.service.GetSubjectDetails(id);
            return View(vm);
        }
    }
}