namespace SchoolSystem.Web.Areas.SchoolDiary.Controllers
{
    using SchoolSystem.Services.Interfaces.SchoolDiary;
    using SchoolSystem.Web.Attritutes;
    using System.Web.Mvc;

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
            return this.View(vms);
        }

        [Route("Subject/{id}")]
        public ActionResult SubjectDetails(int id)
        {
            var vm = this.service.GetSubjectDetails(id);
            return this.View(vm);
        }
    }
}