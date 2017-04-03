using AutoMapper;
using SchoolSystem.Models.EntityModels;
using SchoolSystem.Models.ViewModels.SchoolDiary;
using SchoolSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
