using SchoolSystem.Models.BindingModels;
using SchoolSystem.Models.BindingModels.SchoolDiary.Teachers;
using SchoolSystem.Models.ViewModels.SchoolDiary.Teachers;
using SchoolSystem.Services.Interfaces;
using SchoolSystem.Services.Interfaces.SchoolDiary;
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

        [Route("Student/{id}/AddNote")]
        public ActionResult AddNote()
        {
            return View();
        }

        [HttpPost]
        [Route("Student/{id}/AddNote")]
        public ActionResult AddNote(AddNoteBm bind, int id)
        {
            if (!this.service.IsStudentExists(id))
            {
                this.ModelState.AddModelError("Student", "Student must exist in School diary");
            }

            if (this.ModelState.IsValid)
            {
                this.service.AddNote(bind, id);
                return RedirectToAction("StudentNotes", "Students");
            }

            return this.View();
        }

        [Route("Student/{id}/AddMark")]
        public ActionResult AddMark(int id)
        {
            var vm = this.service.GetStudentForAddMark(id);

            return View(vm);
        }

        [HttpPost]
        [Route("Student/{id}/AddMark")]
        public ActionResult AddMark(MarkVm vm, int id)
        {
            if (!this.service.IsStudentExists(id))
            {
                this.ModelState.AddModelError("Student", "Student must exist in School diary");
            }

            else if (!this.service.IsSubjectNameExists(vm))
            {
                this.ModelState.AddModelError("SubjectName", "Subject must exist in School diary");
            }

            if (this.ModelState.IsValid)
            {
                this.service.AddMark(vm);
                return RedirectToAction("StudentMarks", "Students", new { id = vm.StudentId });
            }

            return this.View(vm);
        }

        [Route("EditMark/{id}")]
        public ActionResult EditMark(int id)
        {
            MarkVm vm = this.service.GetMarkForEdit(id);

            return this.View(vm);
        }

        [HttpPost]
        [Route("EditMark/{id}")]
        public ActionResult EditMark(MarkVm vm, int id)
        {
            if (!this.service.IsStudentExists(vm.StudentId))
            {
                this.ModelState.AddModelError("Student", "Student must exist in School diary");
            }

            else if (!this.service.IsSubjectNameExists(vm))
            {
                this.ModelState.AddModelError("SubjectName", "Subject must exist in School diary");
            }

            if (this.ModelState.IsValid)
            {
                this.service.EditMark(vm, id);
                return RedirectToAction("StudentMarks", "Students", new { id = vm.StudentId });
            }

            return this.View(vm);
        }

        [Route("EditStudentInfo/{id}")]
        public ActionResult EditStudentInfo(int id)
        {
            EditStudentInfoVm vm = this.service.GetStudentInfoById(id);

            return this.View(vm);
        }

        [HttpPost]
        [Route("EditStudentInfo/{id}")]
        public ActionResult EditStudentInfo(EditStudentInfoVm vm, int id)
        {
            if (!this.service.IsStudentExists(id))
            {
                this.ModelState.AddModelError("Student", "Student must exist in School diary");
            }

            if (this.ModelState.IsValid)
            {
                this.service.EditStudentInfo(vm);
                return RedirectToAction("StudentDetails", "Students", new { id = vm.Id });
            }

            return this.View(vm);
        }
    }
}