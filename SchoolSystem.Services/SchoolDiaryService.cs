using AutoMapper;
using SchoolSystem.Models.EntityModels;
using SchoolSystem.Models.ViewModels.SchoolDiary;
using SchoolSystem.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SchoolSystem.Services
{
    public class SchoolDiaryService : Service, ISchoolDiaryService
    {
        public IEnumerable<AllGradesVm> GetAllGrades()
        {
            IEnumerable<Grade> allGrades = this.Context.Grades;
            IEnumerable<AllGradesVm> vms = Mapper.Instance.Map<IEnumerable<Grade>, IEnumerable<AllGradesVm>>(allGrades);

            return vms;
        }

        public IEnumerable<AllSubjectsFromGradeVm> GetAllSubjectsForGrade(int id)
        {
            IEnumerable<Subject> allSubjects = this.Context.Subjects.Where(subject => subject.Grade.Id == id);
            IEnumerable<AllSubjectsFromGradeVm> vms = Mapper.Instance.Map<IEnumerable<Subject>, IEnumerable<AllSubjectsFromGradeVm>>(allSubjects);

            return vms;
        }

        public IEnumerable<AllStudentsFromGradeVm> GetAllStudentsForGrade(int id)
        {
            IEnumerable<Student> allStudents = this.Context.Students.Where(student => student.Grade.Id == id);
            IEnumerable<AllStudentsFromGradeVm> vms = Mapper.Instance.Map<IEnumerable<Student>, IEnumerable<AllStudentsFromGradeVm>>(allStudents);

            return vms;
        }

        public SubjectDetailsVm GetSubjectDetails(int id)
        {
            Subject subject = this.Context.Subjects.FirstOrDefault(s => s.Id == id);
            SubjectDetailsVm vm = Mapper.Instance.Map<Subject, SubjectDetailsVm>(subject);

            return vm;
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
            IEnumerable<Note> notes = this.Context.Notes.Where(n => n.Student.Id == id);

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
            IEnumerable<Mark> notes = this.Context.Marks.Where(n => n.Student.Id == id);

            StudentVm studentVm = Mapper.Instance.Map<Student, StudentVm>(student);
            IEnumerable<MarksVm> marksVm = Mapper.Instance.Map<IEnumerable<Mark>, IEnumerable<MarksVm>>(notes);

            MarksForStudentVm vm = new MarksForStudentVm();
            vm.Student = studentVm;
            vm.Marks = marksVm;

            return vm;
        }
    }
}
