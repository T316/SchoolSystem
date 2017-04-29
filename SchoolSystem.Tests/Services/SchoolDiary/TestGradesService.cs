namespace SchoolSystem.Tests.Controllers.SchoolDiary
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolSystem.Web.Areas.SchoolDiary.Controllers;
    using SchoolSystem.Services.SchoolDiary;
    using SchoolSystem.Services.Interfaces.SchoolDiary;
    using SchoolSystem.Data.Mocks;
    using SchoolSystem.Data.Interfaces;
    using AutoMapper;
    using SchoolSystem.Models.EntityModels;
    using SchoolSystem.Models.ViewModels.SchoolDiary.Grades;
    using System.Collections.Generic;

    [TestClass]
    public class TestGradesService
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
            Subject subject = new Subject()
            {
                Name = "Математика"
            };
            _context.Subjects.Add(subject);

            Grade grade = new Grade()
            {
                Value = 1,
                Subjects = new HashSet<Subject> { subject }
            };
            Grade grade2 = new Grade()
            {
                Value = 2,
                Subjects = new HashSet<Subject> { subject }
            };
            _context.Grades.Add(grade);
            _context.Grades.Add(grade2);

            this._service = new GradesService(this._context);
            this._controller = new GradesController(this._service);
        }

        [TestMethod]
        public void GetAllGrades_ShouldReturnAllGrades()
        {
            var data = _service.GetAllGrades();
            List<AllGradesVm> grades = new List<AllGradesVm>();
            foreach (var grade in data)
            {
                grades.Add(grade);
            }

            Assert.AreEqual(2, grades.Count);
        }
    }
}
