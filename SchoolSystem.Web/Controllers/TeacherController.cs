using SchoolSystem.Models.BindingModels;
using SchoolSystem.Models.BindingModels.Teacher;
using SchoolSystem.Services.Interfaces;
using SchoolSystem.Web.Attritutes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolSystem.Web.Controllers
{
    [MyAuthorize(Roles = "Teacher")]
    [RoutePrefix("SchoolDiary")]
    public class TeacherController : Controller
    {
        private ITeacherService service;

        public TeacherController(ITeacherService service)
        {
            this.service = service;
        }

        [Route("AddAbsence/{id}")]
        public ActionResult AddAbsence(int id)
        {
            this.service.AddAbsence(id);
            return RedirectToAction("StudentAbsences", "SchoolDiary", new { id = id });
        }

        [Route("AddDelay/{id}")]
        public ActionResult AddDelay(int id)
        {
            this.service.AddDelay(id);
            return RedirectToAction("StudentAbsences", "SchoolDiary", new { id = id });
        }

        [Route("AddNote/{id}")]
        public ActionResult AddNote(int id)
        {
            return View();
        }

        [HttpPost]
        [Route("AddNote/{id}")]
        public ActionResult AddNote(AddNoteBm bind, int id)
        {
            this.service.AddNote(bind, id);
            return RedirectToAction("StudentNotes", "SchoolDiary");
        }

        [Route("AddMark/{id}")]
        public ActionResult AddMark(int id)
        {
            return View();
        }

        [HttpPost]
        [Route("AddMark/{id}")]
        public ActionResult AddMark(AddMarkBm bind, int id)
        {
            this.service.AddMark(bind, id);
            return RedirectToAction("StudentMarks", "SchoolDiary");
        }
    }
}