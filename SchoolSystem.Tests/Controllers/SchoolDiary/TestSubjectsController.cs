using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolSystem.Data.Interfaces;
using SchoolSystem.Data.Mocks;
using SchoolSystem.Models.EntityModels;
using SchoolSystem.Models.ViewModels.SchoolDiary.Grades;
using SchoolSystem.Models.ViewModels.SchoolDiary.Students;
using SchoolSystem.Models.ViewModels.SchoolDiary.Subjects;
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
    public class TestSubjectsController
    {
        private SubjectsController _controller;
        private ISubjectsService _service;
        private ISchoolSystemContext _context;

        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Subject, AllSubjectsFromGradeVm>();
                expression.CreateMap<Subject, SubjectDetailsVm>();
            });
        }

        [TestInitialize]
        public void Init()
        {
            this.ConfigureMapper();
            this._context = new FakeSchoolSystemContext();
            this._service = new SubjectsService(this._context);
            this._controller = new SubjectsController(this._service);
        }

        [TestMethod]
        public void AllSubjectsFromGrade_ShouldPass()
        {
            _controller.WithCallTo(c => c.All(1)).ShouldRenderDefaultView()
                .WithModel<IEnumerable<AllSubjectsFromGradeVm>>();
        }

        [TestMethod]
        public void SubjectDetails_ShouldPass()
        {
            _controller.WithCallTo(c => c.SubjectDetails(1)).ShouldRenderDefaultView();
        }
    }
}