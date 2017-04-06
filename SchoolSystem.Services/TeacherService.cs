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
using SchoolSystem.Models.BindingModels.Teachers;
using System.ComponentModel.DataAnnotations;
using SchoolSystem.Models.ViewModels.Teachers;

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
            Mark mark = new Mark();

            Student student = this.Context.Students.FirstOrDefault(s => s.Id == id);
            mark.Student = student;

            Subject subject = this.Context.Subjects.FirstOrDefault(s => s.Name == bind.SubjectName);
            mark.Subject = subject;
            mark.Value = bind.Value;

            this.Context.Marks.Add(mark);
            this.Context.SaveChanges();
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

        public void EditMark(EditMarkVm vm, int id)
        {
            Mark mark = this.Context.Marks.FirstOrDefault(m => m.Id == id);
            Student student = this.Context.Students.FirstOrDefault(s => s.Id == vm.StudentId);
            Subject subject = this.Context.Subjects.FirstOrDefault(s => s.Name == vm.SubjectName);

            mark.Id = vm.Id;
            mark.Subject = subject;
            mark.Value = vm.Value;
            mark.Student = student;

            this.Context.Entry(mark).State = EntityState.Modified;
            this.Context.SaveChanges();
        }

        public EditMarkVm GetMarkForEdit(int id)
        {
            Mark mark = this.Context.Marks.FirstOrDefault(m => m.Id == id);
            EditMarkVm vm = new EditMarkVm();
            vm.Id = id;
            vm.Value = mark.Value;
            vm.SubjectName = mark.Subject.Name;
            vm.StudentId = mark.Student.Id;

            return vm;
        }

        public bool IsStudentExists(int id)
        {
            Student student = this.Context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return false;
            }

            return true;
        }

        public bool IsSubjectNameExists(AddMarkBm bind)
        {
            if (bind.SubjectName == null)
            {
                return true;
            }

            Subject subject = this.Context.Subjects.FirstOrDefault(s => s.Name == bind.SubjectName);
            if (subject == null)
            {
                return false;
            }

            return true;
        }

        public bool IsSubjectNameExists(EditMarkVm vm)
        {
            if (vm.SubjectName == null)
            {
                return true;
            }

            Subject subject = this.Context.Subjects.FirstOrDefault(s => s.Name == vm.SubjectName);
            if (subject == null)
            {
                return false;
            }

            return true;
        }

        public void RemoveAbsence(int id)
        {
            Student student = this.Context.Students.FirstOrDefault(s => s.Id == id);
            if (student.Absences != 0)
            {
                student.Absences--;
                this.Context.Entry(student).State = EntityState.Modified;
                this.Context.SaveChanges();
            }
        }

        public void RemoveDelay(int id)
        {
            Student student = this.Context.Students.FirstOrDefault(s => s.Id == id);
            if (!(student.Absences == 0 && student.Delays == 0))
            {
                if (student.Delays == 0)
                {
                    student.Absences--;
                    student.Delays = 2;
                }
                else
                {
                    student.Delays--;
                }

                this.Context.Entry(student).State = EntityState.Modified;
                this.Context.SaveChanges();
            }
        }
    }
}