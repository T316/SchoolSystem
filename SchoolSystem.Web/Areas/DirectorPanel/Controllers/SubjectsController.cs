using SchoolSystem.Models.BindingModels.DirectorPanel.Subjects;
using SchoolSystem.Services.Interfaces.DirectorPanel;
using SchoolSystem.Web.Attritutes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolSystem.Web.Areas.DirectorPanel.Controllers
{
    [MyAuthorize(Roles = "Director")]
    [RouteArea("DirectorPanel")]
    public class SubjectsController : Controller
    {
        private IDirectorSubjectsService service;

        public SubjectsController(IDirectorSubjectsService service)
        {
            this.service = service;
        }

        [Route("Subjects/All")]
        public ActionResult All()
        {
            var vms = this.service.GetAllGrades();

            return View(vms);
        }

        [Route("Grades/{id}/AddSubject")]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("Grades/{id}/AddSubject")]
        public ActionResult Add(SubjectsBm bind, int id)
        {
            if (this.service.IsSubjectExist(bind, id))
            {
                this.ModelState.AddModelError("Name", "Предметът вече съществува");
            }
            if (ModelState.IsValid)
            {
                this.service.AddSubject(bind, id);
                return RedirectToAction("All");
            }

            return this.View();
        }

        [Route("Subjects/{id}/Remove")]
        public ActionResult Remove(int id)
        {
            this.service.RemoveSubject(id);
            return RedirectToAction("All");
        }

        [Route("Subjects/{id}/AddTeacher")]
        public ActionResult AddTeacher()
        {
            return this.View();
        }

        [HttpPost]
        [Route("Subjects/{id}/AddTeacher")]
        public ActionResult AddTeacher(TeacherBm bind, int id)
        {
            if (!this.service.IsTeacherExist(bind))
            {
                this.ModelState.AddModelError("UserName", "Учителя трябва да съществува в системата");
            }

            if (ModelState.IsValid)
            {
                this.service.AddTeacherToSubject(bind, id);
                return RedirectToAction("All");
            }

            return this.View();
        }


        [Route("Subjects/{id}/EditTeacher")]
        public ActionResult EditTeacher(int id)
        {
            var vm = this.service.GetTeacherToEdit(id);
            return this.View(vm);
        }

        [HttpPost]
        [Route("Subjects/{id}/EditTeacher")]
        public ActionResult EditTeacher(TeacherBm bind, int id)
        {
            if (!this.service.IsTeacherExist(bind))
            {
                this.ModelState.AddModelError("UserName", "Учителя трябва да съществува в системата");
            }

            if (ModelState.IsValid)
            {
                this.service.EditTeacherToSubject(bind, id);
                return RedirectToAction("All");
            }

            return this.View(bind);
        }

        public ActionResult Load(int id)
        {
            var vm = this.service.GetGradeById(id);
            return this.PartialView("_SubjectPartial", vm);
        }
    }
}