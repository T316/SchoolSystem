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

        public DirectorPanelController(IDirectorPanelService service)
        {
            this.service = service;
        }

        [Route]
        public ActionResult AllTeachers()
        {
            var vms = this.service.getAllTeachers();
            return View(vms);
        }
    }
}