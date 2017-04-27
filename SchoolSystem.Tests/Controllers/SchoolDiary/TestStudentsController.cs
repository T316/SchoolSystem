using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolSystem.Data.Interfaces;
using SchoolSystem.Data.Mocks;
using SchoolSystem.Models.EntityModels;
using SchoolSystem.Models.ViewModels.SchoolDiary.Grades;
using SchoolSystem.Models.ViewModels.SchoolDiary.Students;
using SchoolSystem.Services.Interfaces.SchoolDiary;
using SchoolSystem.Services.SchoolDiary;
using SchoolSystem.Web.Areas.SchoolDiary.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace SchoolSystem.Tests.Controllers.SchoolDiary
{
    [TestClass]
    public class TestStudentsController
    {
        private StudentsController _controller;
        private IStudentsService _service;
        private ISchoolSystemContext _context;

        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Student, AllStudentsFromGradeVm>();
                expression.CreateMap<Student, StudentDetailsVm>();
                expression.CreateMap<Note, NotesVm>();
                expression.CreateMap<Mark, MarksVm>();
                expression.CreateMap<Student, StudentVm>();
            });
        }

        [TestInitialize]
        public void Init()
        {
            this.ConfigureMapper();
            this._context = new FakeSchoolSystemContext();
            this._service = new StudentsService(this._context);
            this._controller = new StudentsController(this._service);
        }

        [TestMethod]
        public void AllStudentsFromGrade_ShouldPass()
        {
            _controller.WithCallTo(c => c.All(1)).ShouldRenderDefaultView()
                .WithModel<IEnumerable<AllStudentsFromGradeVm>>();
        }

        [TestMethod]
        public void StudentDetails_ShouldPass()
        {
            _controller.WithCallTo(c => c.StudentDetails(1)).ShouldRenderDefaultView();
        }

        [TestMethod]
        public void StudentNotes_ShouldPass()
        {
            _controller.WithCallTo(c => c.StudentNotes(1)).ShouldRenderDefaultView()
                .WithModel<NotesForStudentVm>();
        }

        [TestMethod]
        public void StudentMarks_ShouldPass()
        {
            _controller.WithCallTo(c => c.StudentMarks(1)).ShouldRenderDefaultView()
                .WithModel<MarksForStudentVm>();
        }

        [TestMethod]
        public void StudentAbsences_ShouldPass()
        {
            _controller.WithCallTo(c => c.StudentAbsences(1)).ShouldRenderDefaultView()
                .WithModel<StudentAbsencesVm>();
        }
    }
}