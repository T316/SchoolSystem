﻿using SchoolSystem.Services.Interfaces.DirectorPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Models.ViewModels.DirectorPanel;
using SchoolSystem.Models.EntityModels;
using AutoMapper;
using SchoolSystem.Models.BindingModels.DirectorPanel.Students;

namespace SchoolSystem.Services.DirectorPanel
{
    public class DirectorStudentsService : Service, IDirectorStudentsService
    {
        public void AddStudent(StudentBm bind, int id)
        {
            Student student = Mapper.Instance.Map<StudentBm, Student>(bind);
            Grade grade = this.Context.Grades.FirstOrDefault(g => g.Id == id);
            student.Grade = grade;

            this.Context.Students.Add(student);
            this.Context.SaveChanges();
        }

        public IEnumerable<DirectorGradeVm> GetAllGrades()
        {
            IEnumerable<Grade> grades = this.Context.Grades.OrderBy(g => g.Value).ThenBy(g => g.Class);
            IEnumerable<DirectorGradeVm> vms = Mapper.Instance.Map<IEnumerable<Grade>, IEnumerable<DirectorGradeVm>>(grades);

            return vms;
        }

        public void RemoveStudent(int id)
        {
            Student student = this.Context.Students.FirstOrDefault(s => s.Id == id);

            this.Context.Marks.RemoveRange(student.Marks);
            this.Context.Notes.RemoveRange(student.Notes);
            this.Context.SaveChanges();

            this.Context.Students.Remove(student);
            this.Context.SaveChanges();
        }
    }
}
