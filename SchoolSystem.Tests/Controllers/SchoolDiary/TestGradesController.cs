namespace SchoolSystem.Tests.Controllers.SchoolDiary
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolSystem.Web.Areas.SchoolDiary.Controllers;
    using SchoolSystem.Services.SchoolDiary;
    using SchoolSystem.Services.Interfaces.SchoolDiary;
    using SchoolSystem.Data.Mocks;
    using SchoolSystem.Data.Interfaces;
    using TestStack.FluentMVCTesting;
    using AutoMapper;
    using SchoolSystem.Models.EntityModels;
    using SchoolSystem.Models.ViewModels.SchoolDiary.Grades;
    using System.Collections.Generic;

    [TestClass]
    public class TestGradesController
    {
        private GradesController _controller;
        private IGradesService _service;
        private ISchoolSystemContext _context;

        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Grade, AllGradesVm>();
            });
        }

        [TestInitialize]
        public void Init()
        {
            this.ConfigureMapper();
            this._context = new FakeSchoolSystemContext();
            this._service = new GradesService(this._context);
            this._controller = new GradesController(this._service);
        }

        [TestMethod]
        public void AllGrades_ShouldPass()
        {
            _controller.WithCallTo(c => c.All()).ShouldRenderDefaultView()
                .WithModel<IEnumerable<AllGradesVm>>();
        }
    }
}
