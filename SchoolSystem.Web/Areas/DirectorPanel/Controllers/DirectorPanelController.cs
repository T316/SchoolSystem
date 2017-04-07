using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SchoolSystem.Data;
using SchoolSystem.Models.BindingModels.DirectorPanel;
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
    public class DirectorPanelController : Controller
    {
        private IDirectorPanelService service;
        private SchoolSystemContext context;
        private ApplicationUserManager _userManager;

        public DirectorPanelController(IDirectorPanelService service)
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

        [Route]
        [Route("AllTeachers")]
        public ActionResult AllTeachers()
        {
            var vms = this.service.getAllTeachers();
            return View(vms);
        }

        [Route("AddTeacher")]
        public ActionResult AddTeacher()
        {

            return this.View();
        }

        [HttpPost]
        [Route("AddTeacher")]
        public ActionResult AddTeacher(AddTeacherBm bind)
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
                return RedirectToAction("AllTeachers", "DirectorPanel");
            }

            return this.View();
        }

        [Route("RemoveTeacher/{id}")]
        public ActionResult RemoveTeacher(int id)
        {
            var teacher = this.service.GetTeacherById(id);     

            if (teacher != null)
            {
                var user = this.service.GetUserByTeacherId(teacher.User.Id);
                this.service.RemoveTeacher(id);
                this.UserManager.RemoveFromRoles(user.Id, "Teacher");
                return RedirectToAction("AllTeachers", "DirectorPanel");
            }

            return RedirectToAction("AllTeachers", "DirectorPanel");
        }
    }
}