using SchoolSystem.Models.BindingModels;
using SchoolSystem.Models.BindingModels.SchoolDiary.Teachers;
using SchoolSystem.Models.ViewModels.SchoolDiary.Teachers;
using SchoolSystem.Services.Interfaces;
using SchoolSystem.Web.Attritutes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolSystem.Web.Areas.SchoolDiary.Controllers
{
    [MyAuthorize(Roles = "Teacher")]
    [RouteArea("SchoolDiary")]
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
            return RedirectToAction("StudentAbsences", "Students", new { id = id });
        }

        [Route("RemoveAbsence/{id}")]
        public ActionResult RemoveAbsence(int id)
        {
            this.service.RemoveAbsence(id);
            return RedirectToAction("StudentAbsences", "Students", new { id = id });
        }

        [Route("AddDelay/{id}")]
        public ActionResult AddDelay(int id)
        {
            this.service.AddDelay(id);
            return RedirectToAction("StudentAbsences", "Students", new { id = id });
        }

        [Route("RemoveDelay/{id}")]
        public ActionResult RemoveDelay(int id)
        {
            this.service.RemoveDelay(id);
            return RedirectToAction("StudentAbsences", "Students", new { id = id });
        }

        [Route("AddNote/{id}")]
        public ActionResult AddNote()
        {
            return View();
        }

        [HttpPost]
        [Route("AddNote/{id}")]
        public ActionResult AddNote(AddNoteBm bind, int id)
        {
            if (this.ModelState.IsValid)
            {
                this.service.AddNote(bind, id);
                return RedirectToAction("StudentNotes", "Students");
            }

            return this.View();
        }

        [Route("AddMark/{id}")]
        public ActionResult AddMark()
        {
            return View();
        }

        [HttpPost]
        [Route("AddMark/{id}")]
        public ActionResult AddMark(AddMarkBm bind, int id)
        {
            if (!this.service.IsSubjectNameExists(bind))
            {
                this.ModelState.AddModelError("SubjectName", "Subject must exist in School diary");
            }

            if (!this.service.IsStudentExists(id))
            {
                this.ModelState.AddModelError("Student", "Student must exist in School diary");
            }

            if (this.ModelState.IsValid)
            {
                this.service.AddMark(bind, id);
                return RedirectToAction("StudentMarks", "Students");
            }

            return this.View();
        }

        [Route("EditMark/{id}")]
        public ActionResult EditMark(int id)
        {
            EditMarkVm vm = this.service.GetMarkForEdit(id);

            return this.View(vm);
        }

        [HttpPost]
        [Route("EditMark/{id}")]
        public ActionResult EditMark(EditMarkVm vm, int id)
        {
            if (!this.service.IsSubjectNameExists(vm))
            {
                this.ModelState.AddModelError("SubjectName", "Subject must exist in School diary");
            }

            if (!this.service.IsStudentExists(vm.StudentId))
            {
                this.ModelState.AddModelError("Student", "Student must exist in School diary");
            }

            if (this.ModelState.IsValid)
            {
                this.service.EditMark(vm, id);
                return RedirectToAction("StudentMarks", "Students", new { id = vm.StudentId });
            }

            return this.View(vm);
        }
    }
}