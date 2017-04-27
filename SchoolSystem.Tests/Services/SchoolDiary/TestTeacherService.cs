using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolSystem.Data.Interfaces;
using SchoolSystem.Data.Mocks;
using SchoolSystem.Models.BindingModels.SchoolDiary.Teachers;
using SchoolSystem.Models.EntityModels;
using SchoolSystem.Models.ViewModels.SchoolDiary.Grades;
using SchoolSystem.Models.ViewModels.SchoolDiary.Students;
using SchoolSystem.Models.ViewModels.SchoolDiary.Teachers;
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
    public class TestTeachersService
    {
        private TeacherController _controller;
        private ITeacherService _service;
        private ISchoolSystemContext _context;

        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Mark, MarksVm>();
                expression.CreateMap<Student, EditStudentInfoVm>();
            });
        }

        [TestInitialize]
        public void Init()
        {
            this.ConfigureMapper();

            this._context = new FakeSchoolSystemContext();
            Student student = new Student()
            {
                Id = 1,
                Name = "Gosho Goshev",
                PersonalNumber = "0011126582"
            };
            Student student2 = new Student()
            {
                Id = 2,
                Name = "Gosho Peshov",
                PersonalNumber = "0110126582"
            };

            Subject subject = new Subject()
            {
                Name = "Математика"
            };
            _context.Subjects.Add(subject);

            Grade grade = new Grade()
            {
                Value = 1,
                Students = new HashSet<Student> { student },
                Subjects = new HashSet<Subject> { subject }
            };
            _context.Grades.Add(grade);

            Grade grade2 = new Grade()
            {
                Value = 2,
                Students = new HashSet<Student> { student2 },
            };
            _context.Grades.Add(grade2);

            Mark mark = new Mark();
            mark.Id = 1;
            mark.Value = 6;
            mark.Student = student;
            mark.Subject = subject;
            _context.Marks.Add(mark);

            student.Grade = grade;
            student2.Grade = grade2;
            _context.Students.Add(student);
            _context.Students.Add(student2);

            this._service = new TeacherService(this._context);
            this._controller = new TeacherController(this._service);
        }

        [TestMethod]
        public void AddMark_ShouldAddMark()
        {
            MarkVm vm = new MarkVm()
            {
                Id = 2,
                StudentId = 1,
                Value = 5,
                SubjectName = "Математика"
            };

            _service.AddMark(vm);
            var mark = _context.Marks.FirstOrDefault(m => m.Id == 2);

            Assert.IsNotNull(mark);
            Assert.AreEqual(1, mark.Student.Id);
            Assert.AreEqual(5, mark.Value);
            Assert.AreEqual("Математика", mark.Subject.Name);
        }

        [TestMethod]
        public void AddNote_ShouldAddNote()
        {
            AddNoteBm bind = new AddNoteBm()
            {
                Content = "Hi"
            };

            _service.AddNote(bind, 1);

            Assert.AreEqual(1, _context.Notes.Count());
            Assert.AreEqual("Hi", _context.Notes.First().Content);
        }


        [TestMethod]
        public void GetMarkForEdit_ShouldReturnMarkVm()
        {
            var mark = _service.GetMarkForEdit(1);

            Assert.AreEqual(1, mark.StudentId);
            Assert.AreEqual("Математика", mark.SubjectName);
            Assert.AreEqual(6, mark.Value);
        }

        [TestMethod]
        public void GetStudentForAddMark_ShouldReturnMarkVm()
        {
            var mark = _service.GetStudentForAddMark(1);

            Assert.AreEqual(1, mark.StudentId);
            Assert.AreEqual("Математика", mark.SubjectName);
            Assert.AreEqual(6, mark.Value);
        }

        [TestMethod]
        public void GetStudentInfoByIdGetStudentForAddMark_ShouldReturnEditStudentInfoVm()
        {
            var vm = _service.GetStudentInfoById(1);

            Assert.AreEqual("Gosho Goshev", vm.Name);
            Assert.AreEqual("0011126582", vm.PersonalNumber);
        }

        [TestMethod]
        public void IsStudentExists_ShouldReturnTrue()
        {
            var isExist = _service.IsStudentExists(1);

            Assert.AreEqual(true, isExist);
        }

        [TestMethod]
        public void IsStudentExists_InvalidStudentId_ShouldReturnFalse()
        {
            var isExist = _service.IsStudentExists(3);

            Assert.AreEqual(false, isExist);
        }

        [TestMethod]
        public void IsSubjectNameExists_ShouldReturnTrue()
        {
            MarkVm vm = new MarkVm()
            {
                StudentId = 1,
                SubjectName = "Математика",
                Value = 6
            };

            var isExists = _service.IsSubjectNameExists(vm);

            Assert.AreEqual(true, isExists);
        }

        [TestMethod]
        public void IsSubjectNameExists_SubjectNameIsNull_ShouldReturnTrue()
        {
            MarkVm vm = new MarkVm()
            {
                StudentId = 1,
                SubjectName = null,
                Value = 6
            };

            var isExists = _service.IsSubjectNameExists(vm);

            Assert.AreEqual(true, isExists);
        }

        [TestMethod]
        public void IsSubjectNameExists_SubjectIsNull_ShouldReturnFalse()
        {
            MarkVm vm = new MarkVm()
            {
                StudentId = 2,
                SubjectName = "Математика",
                Value = 6
            };

            var isExists = _service.IsSubjectNameExists(vm);

            Assert.AreEqual(false, isExists);
        }
    }
}