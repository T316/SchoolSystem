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
    public class StudentsController : Controller
    {
        private IStudentsService service;

        public StudentsController(IStudentsService service)
        {
            this.service = service;
        }

        [Route("Grade/{id}/Students")]
        public ActionResult All(int id)
        {
            var vms = this.service.GetAllStudentsForGrade(id);
            return View(vms);
        }

        [Route("Student/{id}")]
        public ActionResult StudentDetails(int id)
        {
            var vm = this.service.GetStudentDetails(id);
            return View(vm);
        }

        [Route("Student/{id}/Notes")]
        public ActionResult StudentNotes(int id)
        {
            var vm = this.service.GetStudentNotes(id);
            return View(vm);
        }

        [Route("Student/{id}/Marks")]
        public ActionResult StudentMarks(int id)
        {
            var vm = this.service.GetStudentMarks(id);
            return View(vm);
        }


        [Route("Student/{id}/Absences")]
        public ActionResult StudentAbsences(int id)
        {
            var vm = this.service.GetStudentAbsences(id);
            return View(vm);
        }
    }
}