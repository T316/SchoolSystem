namespace SchoolSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Linq;
    using System.Collections.Generic;
    using SchoolSystem.Models.EntityModels;
    using System;
    using System.Data.Entity;

    internal sealed class Configuration : DbMigrationsConfiguration<SchoolSystem.Data.SchoolSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SchoolSystemContext context)
        {
            if (!context.Roles.Any(role => role.Name == "User"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("User");
                manager.Create(role);
            }

            if (!context.Roles.Any(role => role.Name == "Teacher"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Teacher");
                manager.Create(role);
            }

            if (!context.Roles.Any(role => role.Name == "Director"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Director");
                manager.Create(role);
            }

            //Grade grade = context.Grades.FirstOrDefault(g => g.Id == 32);
            //List<Student> students = new List<Student>()
            //{
            //    new Student() {Name = "Йордан Василев", Grade = grade, Address = "Обеля 2", PersonalNumber = "0246046691", ParentName = "Мирослав Тарийски", PhoneNumber = "0895556675", ParentPhone = "0878695473"},
            //    new Student() {Name = "Иван Миланов", Grade = grade, Address = "Обеля 2", PersonalNumber = "0243066689", ParentName = "Симеон Миланов", PhoneNumber = "", ParentPhone = "0878695473"},
            //    new Student() {Name = "Даниел Величков", Grade = grade, Address = "Обеля 2", PersonalNumber = "0248306289", ParentName = "Валя Трайкова", PhoneNumber = "0884680903", ParentPhone = "0878695473"},
            //    new Student() {Name = "Полина Славова", Grade = grade, Address = "Обеля 2", PersonalNumber = "0248246682", ParentName = "Зорница Славова", PhoneNumber = "0884680903", ParentPhone = "0878695473"},
            //    new Student() {Name = "Катя Стефанова", Grade = grade, Address = "Обеля 2", PersonalNumber = "0241176326", ParentName = "Стефан Стефанов", PhoneNumber = "0884680903", ParentPhone = "0895556675"},
            //    new Student() {Name = "Кубрат Миланов", Grade = grade, Address = "Обеля 2", PersonalNumber = "0252076442", ParentName = "Десислава Миланова", PhoneNumber = "0884680903", ParentPhone = "0878695473"},
            //    new Student() {Name = "Майкъл Петров", Grade = grade, Address = "Обеля 2", PersonalNumber = "0246087160", ParentName = "Петя Попова", PhoneNumber = "0884680903", ParentPhone = "0888850117"},
            //    new Student() {Name = "Никол Христова", Grade = grade, Address = "Обеля 1", PersonalNumber = "024886243", ParentName = "Елиза Христова", PhoneNumber = "0884680903", ParentPhone = "0878695473"},
            //    new Student() {Name = "Елица Михайлова", Grade = grade, Address = "Обеля 1", PersonalNumber = "0252226368", ParentName = "Живко Михайлов", PhoneNumber = "0895556675", ParentPhone = "0878695473"},
            //    new Student() {Name = "Никола Мирчев", Grade = grade, Address = "Обеля 1", PersonalNumber = "0251036933", ParentName = "Биляна Мирчева", PhoneNumber = "0888850117", ParentPhone = "0878695473"},
            //    new Student() {Name = "Радослав Иванов", Grade = grade, Address = "Обеля 1", PersonalNumber = "0252176652", ParentName = "Камелия Иванова", PhoneNumber = "0884680903", ParentPhone = "0878695473"},
            //    new Student() {Name = "Ивайло Димитров", Grade = grade, Address = "Обеля 1", PersonalNumber = "0251077059", ParentName = "Силвия Виткова", PhoneNumber = "0884680903", ParentPhone = "0895556675"},
            //    new Student() {Name = "Десислава Борисова", Grade = grade, Address = "Обеля 1", PersonalNumber = "0242076609", ParentName = "Григор Борисов", PhoneNumber = "0884680903", ParentPhone = "0878695473"},
            //    new Student() {Name = "Лили Средкова", Grade = grade, Address = "Обеля 1", PersonalNumber = "0251076535", ParentName = "Димитър Средков", PhoneNumber = "0884680903", ParentPhone = "0878695473"},
            //    new Student() {Name = "Теодора Христова", Grade = grade, Address = "Обеля 1", PersonalNumber = "0251076535", ParentName = "Емил Иванов", PhoneNumber = "0884680903", ParentPhone = "0878695473"},
            //    new Student() {Name = "Божидара Велинова", Grade = grade, Address = "Обеля 1", PersonalNumber = "0251076535", ParentName = "Велин Велинов", PhoneNumber = "0884680903", ParentPhone = "0878695473"},
            //    new Student() {Name = "Елена Росенова", Grade = grade, Address = "Обеля 1", PersonalNumber = "0251076535", ParentName = "Васил Николов", PhoneNumber = "0884680903", ParentPhone = "0878695473"},
            //    new Student() {Name = "Евгени Тодоров", Grade = grade, Address = "Обеля 1", PersonalNumber = "0151076535", ParentName = "Антон Тодоров", PhoneNumber = "0884680903", ParentPhone = "0878695473"},
            //};
            //context.Students.AddRange(students);
        }
    }
}
