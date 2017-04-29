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
            //    new Student() {Name = "������ �������", Grade = grade, Address = "����� 2", PersonalNumber = "0246046691", ParentName = "�������� ��������", PhoneNumber = "0895556675", ParentPhone = "0878695473"},
            //    new Student() {Name = "���� �������", Grade = grade, Address = "����� 2", PersonalNumber = "0243066689", ParentName = "������ �������", PhoneNumber = "", ParentPhone = "0878695473"},
            //    new Student() {Name = "������ ��������", Grade = grade, Address = "����� 2", PersonalNumber = "0248306289", ParentName = "���� ��������", PhoneNumber = "0884680903", ParentPhone = "0878695473"},
            //    new Student() {Name = "������ �������", Grade = grade, Address = "����� 2", PersonalNumber = "0248246682", ParentName = "������� �������", PhoneNumber = "0884680903", ParentPhone = "0878695473"},
            //    new Student() {Name = "���� ���������", Grade = grade, Address = "����� 2", PersonalNumber = "0241176326", ParentName = "������ ��������", PhoneNumber = "0884680903", ParentPhone = "0895556675"},
            //    new Student() {Name = "������ �������", Grade = grade, Address = "����� 2", PersonalNumber = "0252076442", ParentName = "��������� ��������", PhoneNumber = "0884680903", ParentPhone = "0878695473"},
            //    new Student() {Name = "������ ������", Grade = grade, Address = "����� 2", PersonalNumber = "0246087160", ParentName = "���� ������", PhoneNumber = "0884680903", ParentPhone = "0888850117"},
            //    new Student() {Name = "����� ��������", Grade = grade, Address = "����� 1", PersonalNumber = "024886243", ParentName = "����� ��������", PhoneNumber = "0884680903", ParentPhone = "0878695473"},
            //    new Student() {Name = "����� ���������", Grade = grade, Address = "����� 1", PersonalNumber = "0252226368", ParentName = "����� ��������", PhoneNumber = "0895556675", ParentPhone = "0878695473"},
            //    new Student() {Name = "������ ������", Grade = grade, Address = "����� 1", PersonalNumber = "0251036933", ParentName = "������ �������", PhoneNumber = "0888850117", ParentPhone = "0878695473"},
            //    new Student() {Name = "�������� ������", Grade = grade, Address = "����� 1", PersonalNumber = "0252176652", ParentName = "������� �������", PhoneNumber = "0884680903", ParentPhone = "0878695473"},
            //    new Student() {Name = "������ ��������", Grade = grade, Address = "����� 1", PersonalNumber = "0251077059", ParentName = "������ �������", PhoneNumber = "0884680903", ParentPhone = "0895556675"},
            //    new Student() {Name = "��������� ��������", Grade = grade, Address = "����� 1", PersonalNumber = "0242076609", ParentName = "������ �������", PhoneNumber = "0884680903", ParentPhone = "0878695473"},
            //    new Student() {Name = "���� ��������", Grade = grade, Address = "����� 1", PersonalNumber = "0251076535", ParentName = "������� �������", PhoneNumber = "0884680903", ParentPhone = "0878695473"},
            //    new Student() {Name = "������� ��������", Grade = grade, Address = "����� 1", PersonalNumber = "0251076535", ParentName = "���� ������", PhoneNumber = "0884680903", ParentPhone = "0878695473"},
            //    new Student() {Name = "�������� ��������", Grade = grade, Address = "����� 1", PersonalNumber = "0251076535", ParentName = "����� �������", PhoneNumber = "0884680903", ParentPhone = "0878695473"},
            //    new Student() {Name = "����� ��������", Grade = grade, Address = "����� 1", PersonalNumber = "0251076535", ParentName = "����� �������", PhoneNumber = "0884680903", ParentPhone = "0878695473"},
            //    new Student() {Name = "������ �������", Grade = grade, Address = "����� 1", PersonalNumber = "0151076535", ParentName = "����� �������", PhoneNumber = "0884680903", ParentPhone = "0878695473"},
            //};
            //context.Students.AddRange(students);
        }
    }
}
