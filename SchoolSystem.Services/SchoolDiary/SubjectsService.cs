using AutoMapper;
using SchoolSystem.Models.EntityModels;
using SchoolSystem.Models.ViewModels.SchoolDiary;
using SchoolSystem.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System;
using SchoolSystem.Models.ViewModels.SchoolDiary.Subjects;
using SchoolSystem.Services.Interfaces.SchoolDiary;

namespace SchoolSystem.Services.SchoolDiary
{
    public class SubjectsService : Service, ISubjectsService
    {
        public IEnumerable<AllSubjectsFromGradeVm> GetAllSubjectsForGrade(int id)
        {
            IEnumerable<Subject> allSubjects = this.Context.Subjects.Where(subject => subject.Grade.Id == id);
            IEnumerable<AllSubjectsFromGradeVm> vms = Mapper.Instance.Map<IEnumerable<Subject>, IEnumerable<AllSubjectsFromGradeVm>>(allSubjects);

            return vms;
        }

        public SubjectDetailsVm GetSubjectDetails(int id)
        {
            Subject subject = this.Context.Subjects.FirstOrDefault(s => s.Id == id);
            SubjectDetailsVm vm = Mapper.Instance.Map<Subject, SubjectDetailsVm>(subject);

            return vm;
        }
    }
}
