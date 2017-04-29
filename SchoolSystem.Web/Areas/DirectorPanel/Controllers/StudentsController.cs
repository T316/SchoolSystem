namespace SchoolSystem.Web.Areas.DirectorPanel.Controllers
{
    using SchoolSystem.Models.BindingModels.DirectorPanel.Students;
    using SchoolSystem.Services.Interfaces.DirectorPanel;
    using SchoolSystem.Web.Attritutes;
    using System.Web.Mvc;

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

            return this.View(vms);
        }

        [Route("Grades/{id}/AddStudent")]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Route("Grades/{id}/AddStudent")]
        public ActionResult Add(StudentBm bind, int id)
        {
            if (ModelState.IsValid)
            {
                this.service.AddStudent(bind, id);
                return this.RedirectToAction("All");
            }

            return this.View();
        }

        [Route("Students/{id}/Remove")]
        public ActionResult Remove(int id)
        {
            this.service.RemoveStudent(id);
            return this.RedirectToAction("All");
        }

        public ActionResult Load(int id)
        {
            var vm = this.service.GetGradeById(id);
            return this.PartialView("_StudentPartial", vm);
        }
    }
}