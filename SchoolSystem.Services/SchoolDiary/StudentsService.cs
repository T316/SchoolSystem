using AutoMapper;
using SchoolSystem.Models.EntityModels;
using SchoolSystem.Models.ViewModels.SchoolDiary;
using SchoolSystem.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;
using SchoolSystem.Models.ViewModels.SchoolDiary.Students;
using SchoolSystem.Services.Interfaces.SchoolDiary;

namespace SchoolSystem.Services.SchoolDiary
{
    public class StudentsService : Service, IStudentsService
    {

        public IEnumerable<AllStudentsFromGradeVm> GetAllStudentsForGrade(int id)
        {
            IEnumerable<Student> allStudents = this.Context.Students.Where(student => student.Grade.Id == id);
            IEnumerable<AllStudentsFromGradeVm> vms = Mapper.Instance.Map<IEnumerable<Student>, IEnumerable<AllStudentsFromGradeVm>>(allStudents);

            return vms;
        }

        public StudentDetailsVm GetStudentDetails(int id)
        {
            Student student = this.Context.Students.FirstOrDefault(s => s.Id == id);
            StudentDetailsVm vm = Mapper.Instance.Map<Student, StudentDetailsVm>(student);

            return vm;
        }

        public NotesForStudentVm GetStudentNotes(int id)
        {
            Student student = this.Context.Students.FirstOrDefault(s => s.Id == id);
            IEnumerable<Note> notes = this.Context.Notes.Where(n => n.Student.Id == id).OrderByDescending(n => n.Date);

            StudentVm studentVm = Mapper.Instance.Map<Student, StudentVm>(student);
            IEnumerable<NotesVm> notesVms = Mapper.Instance.Map<IEnumerable<Note>, IEnumerable<NotesVm>>(notes);

            NotesForStudentVm vm = new NotesForStudentVm();
            vm.Student = studentVm;
            vm.Notes = notesVms;

            return vm;
        }

        public MarksForStudentVm GetStudentMarks(int id)
        {
            Student student = this.Context.Students.FirstOrDefault(s => s.Id == id);
            IEnumerable<Mark> marks = this.Context.Marks.Where(n => n.Student.Id == id).OrderByDescending(m => m.Date);

            StudentVm studentVm = Mapper.Instance.Map<Student, StudentVm>(student);
            IEnumerable<MarksVm> marksVm = Mapper.Instance.Map<IEnumerable<Mark>, IEnumerable<MarksVm>>(marks);

            MarksForStudentVm vm = new MarksForStudentVm();
            vm.Student = studentVm;
            vm.Marks = marksVm;

            return vm;
        }

        public StudentAbsencesVm GetStudentAbsences(int id)
        {
            Student student = this.Context.Students.FirstOrDefault(s => s.Id == id);
            StudentAbsencesVm vm = new StudentAbsencesVm();
            vm.Student = student;

            return vm;
        }
    }
}
