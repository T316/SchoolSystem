namespace SchoolSystem.Web.Areas.DirectorPanel.Controllers
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using SchoolSystem.Data;
    using SchoolSystem.Models.BindingModels.DirectorPanel.Teachers;
    using SchoolSystem.Services.Interfaces.DirectorPanel;
    using SchoolSystem.Web.Attritutes;
    using System.Web;
    using System.Web.Mvc;

    [MyAuthorize(Roles = "Director")]
    [RouteArea("DirectorPanel")]
    [RoutePrefix("Teachers")]
    public class TeachersController : Controller
    {
        private IDirectorTeachersService service;
        private SchoolSystemContext context;
        private ApplicationUserManager _userManager;

        public TeachersController(IDirectorTeachersService service)
        {
            this.context = new SchoolSystemContext();
            this.service = service;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        [Route("All")]
        public ActionResult All()
        {
            var vms = this.service.getAllTeachers();
            return this.View(vms);
        }

        [Route("Add")]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult Add(AddTeacherBm bind)
        {
            var user = this.service.GetUserByUserName(bind.UserName);

            if (user == null)
            {
                this.ModelState.AddModelError("UserName", "Потребителя трябва да съществува.");
            }

            else if (this.service.IsAlreadyTheacher(user))
            {
                this.ModelState.AddModelError("UserName", "Потребителя вече е учител.");
            }

            if (this.ModelState.IsValid)
            {
                this.service.AddTeacher(user);
                this.UserManager.AddToRole(user.Id, "Teacher");
                return this.RedirectToAction("All");
            }

            return this.View();
        }

        [Route("Remove/{id}")]
        public ActionResult Remove(int id)
        {
            var teacher = this.service.GetTeacherById(id);     

            if (teacher != null)
            {
                var user = this.service.GetUserByTeacherId(teacher.User.Id);
                this.service.RemoveTeacher(id);
                this.UserManager.RemoveFromRoles(user.Id, "Teacher");
                return this.RedirectToAction("All");
            }

            return this.RedirectToAction("All");
        }
    }
}