namespace SchoolSystem.Data.Interfaces
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using SchoolSystem.Models.EntityModels;

    public interface ISchoolSystemContext
    {
        DbSet<Teacher> Teachers { get; set; }

        DbSet<Student> Students { get; set; }

        DbSet<Grade> Grades { get; set; }

        DbSet<Subject> Subjects { get; set; }

        DbSet<Mark> Marks { get; set; }

        DbSet<Note> Notes { get; set; }

        IDbSet<User> Users { get; set; }

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}
