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
    public class TestSubjectsService
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

            Subject subject = new Subject()
            {
                Id = 1,
                Name = "Математика"
            };
            Subject subject2 = new Subject()
            {
                Id = 2,
                Name = "Български език"
            };

            Grade grade = new Grade()
            {
                Id = 1,
                Value = 1,
                Subjects = new HashSet<Subject> { subject, subject2 }
            };
            _context.Grades.Add(grade);

            subject.Grade = grade;
            subject2.Grade = grade;
            _context.Subjects.Add(subject);
            _context.Subjects.Add(subject2);

            this._service = new SubjectsService(this._context);
            this._controller = new SubjectsController(this._service);
        }

        [TestMethod]
        public void GetAllSubjectsFromGrade_ShouldReturnAllSubjectsFromGrade()
        {
            var data = _service.GetAllSubjectsForGrade(1);
            List<AllSubjectsFromGradeVm> subjects = new List<AllSubjectsFromGradeVm>();
            foreach (var subject in data)
            {
                subjects.Add(subject);
            }

            Assert.AreEqual(2, subjects.Count);
            Assert.AreEqual("Математика", subjects[0].Name);
            Assert.AreEqual("Български език", subjects[1].Name);
        }

        [TestMethod]
        public void GetSubjectDetails_ShouldReturnSubjectDetails()
        {
            var subject = _service.GetSubjectDetails(1);

            Assert.AreEqual("Математика", subject.Name);
            Assert.AreEqual(1, subject.Grade.Id);
            Assert.AreEqual(1, subject.Grade.Value);
        }
    }
}