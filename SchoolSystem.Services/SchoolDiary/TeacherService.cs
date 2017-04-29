namespace SchoolSystem.Services.SchoolDiary
{
    using SchoolSystem.Models.EntityModels;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using AutoMapper;
    using SchoolSystem.Models.BindingModels.SchoolDiary.Teachers;
    using SchoolSystem.Models.ViewModels.SchoolDiary.Teachers;
    using SchoolSystem.Services.Interfaces.SchoolDiary;
    using SchoolSystem.Data.Interfaces;

    public class TeacherService : Service, ITeacherService
    {
        public TeacherService(ISchoolSystemContext context) : base(context)
        {
        }

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

        public void AddMark(MarkVm vm)
        {
            Mark mark = new Mark();
            Student student = this.Context.Students.FirstOrDefault(s => s.Id == vm.StudentId);
            Subject subject = this.Context.Subjects.FirstOrDefault(s => s.Name == vm.SubjectName);

            mark.Id = vm.Id;
            mark.Subject = subject;
            mark.Value = vm.Value;
            mark.Student = student;
            mark.Date = DateTime.Now;

            this.Context.Marks.Add(mark);
            this.Context.SaveChanges();
        }

        public void AddNote(AddNoteBm bind, int id)
        {
            Note note = new Note();

            note.Content = bind.Content;
            note.Date = DateTime.Now;

            string username = bind.TeacherName;
            Teacher teacher = this.Context.Teachers.FirstOrDefault(t => t.User.UserName == username);
            note.Teacher = teacher;

            Student student = this.Context.Students.FirstOrDefault(s => s.Id == id);
            note.Student = student;

            this.Context.Notes.Add(note);
            this.Context.SaveChanges();
        }

        public void EditMark(MarkVm vm, int id)
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

        public void EditStudentInfo(EditStudentInfoVm vm)
        {
            Student student = this.Context.Students.FirstOrDefault(s => s.Id == vm.Id);
            student.Name = vm.Name;
            student.PersonalNumber = vm.PersonalNumber;
            student.Address = vm.Address;
            student.PhoneNumber = vm.PhoneNumber;
            student.ParentName = vm.ParentName;
            student.ParentPhone = vm.ParentPhone;

            this.Context.Entry(student).State = EntityState.Modified;
            this.Context.SaveChanges();
        }

        public MarkVm GetMarkForEdit(int id)
        {
            Mark mark = this.Context.Marks.FirstOrDefault(m => m.Id == id);
            MarkVm vm = new MarkVm();
            vm.Id = id;
            vm.Value = mark.Value;
            vm.SubjectName = mark.Subject.Name;
            vm.StudentId = mark.Student.Id;

            return vm;
        }

        public MarkVm GetStudentForAddMark(int id)
        {
            Student student = this.Context.Students.FirstOrDefault(s => s.Id == id);
            MarkVm vm = new MarkVm();
            vm.StudentId = id;
            vm.Value = 6;
            vm.SubjectName = student.Grade.Subjects.Select(s => s.Name).FirstOrDefault(s => s != null);

            return vm;
        }

        public EditStudentInfoVm GetStudentInfoById(int id)
        {
            Student student = this.Context.Students.FirstOrDefault(s => s.Id == id);
            EditStudentInfoVm vm = Mapper.Instance.Map<Student, EditStudentInfoVm>(student);

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

        public bool IsSubjectNameExists(MarkVm vm)
        {
            if (vm.SubjectName == null)
            {
                return true;
            }

            Student student = this.Context.Students.FirstOrDefault(s => s.Id == vm.StudentId);
            Subject subject = student.Grade.Subjects.FirstOrDefault(s => s.Name == vm.SubjectName);
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