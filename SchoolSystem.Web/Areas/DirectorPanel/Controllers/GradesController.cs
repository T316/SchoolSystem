using SchoolSystem.Models.ViewModels.DirectorPanel;
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
    [RoutePrefix("Grades")]
    public class GradesController : Controller
    {
        private IDirectorGradesService service;

        public GradesController(IDirectorGradesService service)
        {
            this.service = service;
        }

        [Route("All")]
        public ActionResult All()
        {
            var vms = this.service.GetAllGrades();
            return View(vms);
        }

        [Route("Add")]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult Add(DirectorGradeVm bind)
        {
            if (this.service.IsGradeExist(bind))
            {
                this.ModelState.AddModelError("Value", "Grade already exist");
            }

            if (this.ModelState.IsValid)
            {
                this.service.AddGrade(bind);
                return RedirectToAction("All");
            }
            
            return View();
        }

        [Route("Remove/{id}")]
        public ActionResult Remove(int id)
        {
            this.service.RemoveGrade(id);
            return RedirectToAction("All");
        }
    }
}