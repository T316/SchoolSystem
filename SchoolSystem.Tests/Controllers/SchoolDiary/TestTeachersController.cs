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
    public class TestTeachersController
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

            Mark mark = new Mark();
            mark.Id = 1;
            mark.Value = 6;
            mark.Student = student;
            mark.Subject = subject;
            _context.Marks.Add(mark);

            student.Grade = grade;
            _context.Students.Add(student);

            this._service = new TeacherService(this._context);
            this._controller = new TeacherController(this._service);
        }

        [TestMethod]
        public void AddNote_ShouldPass()
        {
            _controller.WithCallTo(c => c.AddNote()).ShouldRenderDefaultView();
        }

        [TestMethod]
        public void AddNote_ShouldRedirectToStudentNotes()
        {
            AddNoteBm bind = new AddNoteBm()
            {
                Content = "Hi"
            };

            _controller.WithCallTo(c => c.AddNote(bind, 1))
                 .ShouldRedirectTo<StudentsController>(typeof(StudentsController).GetMethod("StudentNotes"));
        }

        [TestMethod]
        public void AddNote_InvalidStudent_ShouldReturnDefaultView()
        {
            AddNoteBm bind = new AddNoteBm()
            {
                Content = "Hi"
            };

            _controller.WithCallTo(c => c.AddNote(bind, 2)).ShouldRenderDefaultView();
        }

        [TestMethod]
        public void AddMark_ShouldPass()
        {
            _controller.WithCallTo(c => c.AddMark(1)).ShouldRenderDefaultView()
                .WithModel<MarkVm>();
        }

        [TestMethod]
        public void AddMark_ShouldRedirectToStudentMarks()
        {
            MarkVm vm = new MarkVm()
            {
                StudentId = 1,
                SubjectName = "Математика",
                Value = 6
            };

            _controller.WithCallTo(c => c.AddMark(vm, 1))
                 .ShouldRedirectTo<StudentsController>(typeof(StudentsController).GetMethod("StudentMarks"));
        }

        [TestMethod]
        public void AddMark_InvalidStudent_ShouldReturnDefaultView()
        {
            MarkVm vm = new MarkVm()
            {
                SubjectName = "Математика",
                Value = 6
            };

            _controller.WithCallTo(c => c.AddMark(vm, 2)).ShouldRenderDefaultView();
        }

        [TestMethod]
        public void AddMark_InvalidSubjectName_ShouldReturnDefaultView()
        {
            MarkVm vm = new MarkVm()
            {
                StudentId = 1,
                SubjectName = "Час по бъркане в носа",
                Value = 6
            };

            _controller.WithCallTo(c => c.AddMark(vm, 1)).ShouldRenderDefaultView();
        }

        [TestMethod]
        public void EditMark_ShouldPass()
        {
            _controller.WithCallTo(c => c.EditMark(1)).ShouldRenderDefaultView()
                .WithModel<MarkVm>();
        }

        [TestMethod]
        public void EditMark_InvalidStudent_ShouldReturnDefaultView()
        {
            MarkVm vm = new MarkVm()
            {
                SubjectName = "Математика",
                Value = 6
            };

            _controller.WithCallTo(c => c.EditMark(vm, 2)).ShouldRenderDefaultView();
        }

        [TestMethod]
        public void EditMark_InvalidSubjectName_ShouldReturnDefaultView()
        {
            MarkVm vm = new MarkVm()
            {
                StudentId = 1,
                SubjectName = "Час по бъркане в носа",
                Value = 6
            };

            _controller.WithCallTo(c => c.EditMark(vm, 1)).ShouldRenderDefaultView();
        }

        [TestMethod]
        public void EditStudentInfo_ShouldPass()
        {
            _controller.WithCallTo(c => c.EditStudentInfo(1)).ShouldRenderDefaultView()
                .WithModel<EditStudentInfoVm>();
        }

        [TestMethod]
        public void EditStudentInfo_InvalidStudent_ShouldReturnDefaultView()
        {
            EditStudentInfoVm vm = new EditStudentInfoVm()
            {
                Id = 1,
                Name = "Gosho Goshev",
                PersonalNumber = "0011126582"
            };

            _controller.WithCallTo(c => c.EditStudentInfo(vm, 2)).ShouldRenderDefaultView();
        }
    }
}