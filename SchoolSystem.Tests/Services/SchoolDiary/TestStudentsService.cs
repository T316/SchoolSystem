namespace SchoolSystem.Tests.Controllers.SchoolDiary
{
    using AutoMapper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolSystem.Data.Interfaces;
    using SchoolSystem.Data.Mocks;
    using SchoolSystem.Models.EntityModels;
    using SchoolSystem.Models.ViewModels.SchoolDiary.Students;
    using SchoolSystem.Services.Interfaces.SchoolDiary;
    using SchoolSystem.Services.SchoolDiary;
    using SchoolSystem.Web.Areas.SchoolDiary.Controllers;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class TestStudentsService
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
                PersonalNumber = "0108126582"
            };

            Subject subject = new Subject()
            {
                Name = "Математика"
            };
            _context.Subjects.Add(subject);

            Grade grade = new Grade()
            {
                Id = 1,
                Value = 1,
                Students = new HashSet<Student> { student, student2 },
                Subjects = new HashSet<Subject> { subject }
            };
            _context.Grades.Add(grade);

            Mark mark = new Mark();
            mark.Id = 1;
            mark.Value = 6;
            mark.Student = student;
            mark.Subject = subject;
            _context.Marks.Add(mark);

            Note note = new Note()
            {
                Id = 1,
                Content = "Hi",
                Student = student
            };
            _context.Notes.Add(note);

            student.Grade = grade;
            student.Notes = new HashSet<Note>() { note };
            student2.Grade = grade;
            _context.Students.Add(student);
            _context.Students.Add(student2);

            this._service = new StudentsService(this._context);
            this._controller = new StudentsController(this._service);
        }

        [TestMethod]
        public void GetAllStudentsFromGrade_ShouldReturnAllStudentsFromGrade()
        {
            var data = _service.GetAllStudentsForGrade(1);
            List<AllStudentsFromGradeVm> students = new List<AllStudentsFromGradeVm>();
            foreach (var student in data)
            {
                students.Add(student);
            }

            Assert.AreEqual(2, students.Count);
            Assert.AreEqual("Gosho Goshev", students[0].Name);
            Assert.AreEqual("Gosho Peshov", students[1].Name);
        }

        [TestMethod]
        public void GetStudentDetails_ShouldReturnStudentDetails()
        {
            var student = _service.GetStudentDetails(1);

            Assert.AreEqual("Gosho Goshev", student.Name);
            Assert.AreEqual("0011126582", student.PersonalNumber);
        }

        [TestMethod]
        public void GetStudentNotes_ShouldReturnStudentNotes()
        {
            var notes = _service.GetStudentNotes(1);

            Assert.AreEqual(1, notes.Notes.Count());
            Assert.AreEqual("Hi", notes.Notes.First().Content);
        }

        [TestMethod]
        public void GetStudentMarks_ShouldReturnStudentMarks()
        {
            var marks = _service.GetStudentMarks(1);

            Assert.AreEqual(1, marks.Marks.Count());
            Assert.AreEqual(6, marks.Marks.First().Value);
            Assert.AreEqual("Математика", marks.Marks.First().Subject.Name);
        }

        [TestMethod]
        public void GetStudentAbsences_ShouldReturnStudentAbsences()
        {
            var absences = _service.GetStudentAbsences(1);

            Assert.AreEqual(1, absences.Student.Id);
            Assert.AreEqual("Gosho Goshev", absences.Student.Name);
            Assert.AreEqual("0011126582", absences.Student.PersonalNumber);
        }
    }
}