namespace SchoolSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using SchoolSystem.Data.Interfaces;
    using SchoolSystem.Models.EntityModels;
    using System.Data.Entity;
    using System;

    public class SchoolSystemContext : IdentityDbContext<User>, ISchoolSystemContext
    {
        public SchoolSystemContext()
            : base("name=SchoolSystem")
        {
        }

        public virtual DbSet<Teacher> Teachers { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Grade> Grades { get; set; }

        public virtual DbSet<Subject> Subjects { get; set; }

        public virtual DbSet<Mark> Marks { get; set; }

        public virtual DbSet<Note> Notes { get; set; }

        public override IDbSet<User> Users { get => base.Users; set => base.Users = value; }

        public static SchoolSystemContext Create()
        {
            return new SchoolSystemContext();
        }
    }
}