namespace SchoolSystem.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using SchoolSystem.Models.EntityModels;
    using System.Data.Entity;

    public class SchoolSystemContext : IdentityDbContext<User>
    {
        public SchoolSystemContext()
            : base("name=SchoolSystem")
        {
        }

        public virtual DbSet<Teacher> Teacheres { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Grade> Grades { get; set; }

        public virtual DbSet<Subject> Subjects { get; set; }

        public virtual DbSet<Mark> Marks { get; set; }

        public virtual DbSet<Note> Notes { get; set; }


        public static SchoolSystemContext Create()
        {
            return new SchoolSystemContext();
        }
    }
}