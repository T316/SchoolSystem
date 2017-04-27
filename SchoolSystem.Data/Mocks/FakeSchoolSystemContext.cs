using SchoolSystem.Data.Interfaces;
using SchoolSystem.Models.EntityModels;
using System.Data.Entity;
using System;
using System.Data.Entity.Infrastructure;

namespace SchoolSystem.Data.Mocks
{
    public class FakeSchoolSystemContext : ISchoolSystemContext
    {
        public FakeSchoolSystemContext()
        {
            this.Grades = new FakeGradesDbSet();
            this.Marks = new FakeMarksDbSet();
            this.Notes = new FakeNotesDbSet();
            this.Students = new FakeStudentsDbSet();
            this.Subjects = new FakeSubjectsDbSet();
            this.Teachers = new FakeTeachersDbSet();
        }

        public virtual DbSet<Teacher> Teachers { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Grade> Grades { get; set; }

        public virtual DbSet<Subject> Subjects { get; set; }

        public virtual DbSet<Mark> Marks { get; set; }

        public virtual DbSet<Note> Notes { get; set; }

        public virtual IDbSet<User> Users { get; set; }

        public DbEntityEntry<T> Entry<T>(T entity) where T : class
        {
            return null;
        }

        public int SaveChanges()
        {
            return 0;
        }
    }
}
