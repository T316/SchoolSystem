using SchoolSystem.Models.BindingModels.DirectorPanel.Students;
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
    public class StudentsController : Controller
    {
        private IDirectorStudentsService service;

        public StudentsController(IDirectorStudentsService service)
        {
            this.service = service;
        }

        [Route("All")]
        public ActionResult All()
        {
            var vms = this.service.GetAllGrades();

            return View(vms);
        }

        [Route("Grades/{id}/AddStudent")]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("Grades/{id}/AddStudent")]
        public ActionResult Add(StudentBm bind, int id)
        {
            if (ModelState.IsValid)
            {
                this.service.AddStudent(bind, id);
                return RedirectToAction("All");
            }

            return this.View();
        }

        [Route("Students/{id}/Remove")]
        public ActionResult Remove(int id)
        {
            this.service.RemoveStudent(id);
            return RedirectToAction("All");
        }

        public ActionResult Load(int id)
        {
            var vm = this.service.GetGradeById(id);
            return this.PartialView("_StudentPartial", vm);
        }
    }
}