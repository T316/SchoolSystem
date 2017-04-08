using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SchoolSystem.Data;
using SchoolSystem.Models.BindingModels.DirectorPanel;
using SchoolSystem.Models.BindingModels.DirectorPanel.Teachers;
using SchoolSystem.Services.Interfaces;
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
    [RoutePrefix("Teachers")]
    public class TeachersController : Controller
    {
        private ITeachersService service;
        private SchoolSystemContext context;
        private ApplicationUserManager _userManager;

        public TeachersController(ITeachersService service)
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
            return View(vms);
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
                this.ModelState.AddModelError("UserName", "Username must exist");
            }

            if (this.ModelState.IsValid)
            {
                this.service.AddTeacher(user);
                this.UserManager.AddToRole(user.Id, "Teacher");
                return RedirectToAction("All");
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
                return RedirectToAction("All");
            }

            return RedirectToAction("All");
        }
    }
}