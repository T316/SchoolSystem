using SchoolSystem.Services;
using SchoolSystem.Services.Interfaces;
using SchoolSystem.Web.Attritutes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolSystem.Web.Controllers
{
    [MyAuthorize]
    [RoutePrefix("SchoolDiary")]
    public class SchoolDiaryController : Controller
    {
        private ISchoolDiaryService service;

        public SchoolDiaryController(ISchoolDiaryService service)
        {
            this.service = service;
        }

        [Route]
        [Route("Grades")]
        public ActionResult Grades()
        {
            var vms = this.service.GetAllGrades();
            return View(vms);
        }

        [Route("Grade/{id}/Subjects")]
        public ActionResult AllSubjects(int id)
        {
            var vms = this.service.GetAllSubjectsForGrade(id);
            return View(vms);
        }

        [Route("Subject/{id}")]
        public ActionResult SubjectDetails(int id)
        {
            var vm = this.service.GetSubjectDetails(id);
            return View(vm);
        }


        [Route("Grade/{id}/Students")]
        public ActionResult AllStudents(int id)
        {
            var vms = this.service.GetAllStudentsForGrade(id);
            return View(vms);
        }

        [Route("Student/{id}")]
        public ActionResult StudentDetails(int id)
        {
            var vm = this.service.GetStudentDetails(id);
            return View(vm);
        }

        [Route("Student/{id}/Notes")]
        public ActionResult StudentNotes(int id)
        {
            var vm = this.service.GetStudentNotes(id);
            return View(vm);
        }

        [Route("Student/{id}/Marks")]
        public ActionResult StudentMarks(int id)
        {
            var vm = this.service.GetStudentMarks(id);
            return View(vm);
        }


        [Route("Student/{id}/Absences")]
        public ActionResult StudentAbsences(int id)
        {
            var vm = this.service.GetStudentAbsences(id);
            return View(vm);
        }
    }
}