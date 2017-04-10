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
    [RoutePrefix("Subjects")]
    public class SubjectsController : Controller
    {
        private IDirectorSubjectsService service;

        public SubjectsController(IDirectorSubjectsService service)
        {
            this.service = service;
        }

        [Route("All")]
        public ActionResult All()
        {
            var vms = this.service.GetAllGrades();

            return View(vms);
        }
    }
}