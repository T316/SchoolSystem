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
    }
}