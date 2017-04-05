using SchoolSystem.Models.EntityModels;
using SchoolSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem.Models.BindingModels;
using AutoMapper;
using System.Security.Principal;
using System.Web;
using SchoolSystem.Models.BindingModels.Teacher;

namespace SchoolSystem.Services
{
    public class TeacherService : Service, ITeacherService
    {
        public void AddAbsence(int id)
        {
            Student student = this.Context.Students.FirstOrDefault(s => s.Id == id);
            student.Absences++;
            this.Context.Entry(student).State = EntityState.Modified;
            this.Context.SaveChanges();
        }

        public void AddDelay(int id)
        {
            Student student = this.Context.Students.FirstOrDefault(s => s.Id == id);
            if (student.Delays == 2)
            {
                student.Absences++;
                student.Delays = 0;
            }
            else
            {
                student.Delays++;
            }

            this.Context.Entry(student).State = EntityState.Modified;
            this.Context.SaveChanges();
        }

        public void AddMark(AddMarkBm bind, int id)
        {
            bool IsValid = true;
            Mark mark = new Mark();

            Student student = this.Context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                IsValid = false;
            }

            mark.Student = student;

            Subject subject = this.Context.Subjects.FirstOrDefault(s => s.Name == bind.SubjectName);
            if (subject == null)
            {
                IsValid = false;
            }

            mark.Subject = subject;

            if (bind.Value == 0)
            {
                IsValid = false;
            }

            mark.Value = bind.Value;

            if (IsValid)
            {
                this.Context.Marks.Add(mark);
                this.Context.SaveChanges();
            }
        }

        public void AddNote(AddNoteBm bind, int id)
        {
            Note note = new Note();

            note.Content = bind.Content;
            note.Date = DateTime.Now;

            string username = bind.TeacherName;
            Teacher teacher = this.Context.Teacheres.FirstOrDefault(t => t.User.UserName == username);
            note.Teacher = teacher;

            Student student = this.Context.Students.FirstOrDefault(s => s.Id == id);
            note.Student = student;

            this.Context.Notes.Add(note);
            this.Context.SaveChanges();
        }
    }
}
