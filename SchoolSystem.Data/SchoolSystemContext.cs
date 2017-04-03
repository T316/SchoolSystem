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

        public DbSet<Teacher> Teacheres { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Grade> Grades { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public DbSet<Mark> Marks { get; set; }

        public DbSet<Note> Notes { get; set; }


        public static SchoolSystemContext Create()
        {
            return new SchoolSystemContext();
        }
    }
}