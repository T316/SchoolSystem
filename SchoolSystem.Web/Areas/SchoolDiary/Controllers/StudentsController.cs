namespace SchoolSystem.Web.Areas.SchoolDiary.Controllers
{
    using SchoolSystem.Services.Interfaces.SchoolDiary;
    using SchoolSystem.Web.Attritutes;
    using System.Web.Mvc;

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
            return this.View(vms);
        }

        [Route("Student/{id}")]
        public ActionResult StudentDetails(int id)
        {
            var vm = this.service.GetStudentDetails(id);
            return this.View(vm);
        }

        [Route("Student/{id}/Notes")]
        public ActionResult StudentNotes(int id)
        {
            var vm = this.service.GetStudentNotes(id);
            return this.View(vm);
        }

        [Route("Student/{id}/Marks")]
        public ActionResult StudentMarks(int id)
        {
            var vm = this.service.GetStudentMarks(id);
            return this.View(vm);
        }

        [Route("Student/{id}/Absences")]
        public ActionResult StudentAbsences(int id)
        {
            var vm = this.service.GetStudentAbsences(id);
            return this.View(vm);
        }
    }
}