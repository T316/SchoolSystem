namespace SchoolSystem.Web.Areas.DirectorPanel.Controllers
{
    using SchoolSystem.Models.ViewModels.DirectorPanel;
    using SchoolSystem.Services.Interfaces.DirectorPanel;
    using SchoolSystem.Web.Attritutes;
    using System.Web.Mvc;

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
            return this.View(vms);
        }

        [Route("Add")]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult Add(DirectorGradeVm bind)
        {
            if (this.service.IsGradeExist(bind))
            {
                this.ModelState.AddModelError("Value", "Класът вече съществува");
            }

            if (this.ModelState.IsValid)
            {
                this.service.AddGrade(bind);
                return this.RedirectToAction("All");
            }
            
            return this.View();
        }

        [Route("Remove/{id}")]
        public ActionResult Remove(int id)
        {
            this.service.RemoveGrade(id);
            return this.RedirectToAction("All");
        }
    }
}