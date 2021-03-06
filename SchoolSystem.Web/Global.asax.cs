﻿namespace SchoolSystem.Web
{
    using AutoMapper;
    using SchoolSystem.Models.BindingModels.DirectorPanel.Students;
    using SchoolSystem.Models.BindingModels.DirectorPanel.Subjects;
    using SchoolSystem.Models.EntityModels;
    using SchoolSystem.Models.ViewModels.DirectorPanel;
    using SchoolSystem.Models.ViewModels.DirectorPanel.Grades;
    using SchoolSystem.Models.ViewModels.SchoolDiary.Grades;
    using SchoolSystem.Models.ViewModels.SchoolDiary.Students;
    using SchoolSystem.Models.ViewModels.SchoolDiary.Subjects;
    using SchoolSystem.Models.ViewModels.SchoolDiary.Teachers;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            this.RegisterMaps();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterMaps()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Grade, AllGradesVm>();
                expression.CreateMap<Grade, DirectorGradeVm>();
                expression.CreateMap<Grade, DirectorAllGradesVm>();
                expression.CreateMap<Subject, AllSubjectsFromGradeVm>();
                expression.CreateMap<Subject, SubjectDetailsVm>();
                expression.CreateMap<Student, AllStudentsFromGradeVm>();
                expression.CreateMap<Student, StudentDetailsVm>();
                expression.CreateMap<Student, StudentVm>();
                expression.CreateMap<Note, NotesVm>();
                expression.CreateMap<Mark, MarksVm>();
                expression.CreateMap<Teacher, DirectorAllTeachersVm>();
                expression.CreateMap<Student, EditStudentInfoVm>();
                expression.CreateMap<DirectorGradeVm, Grade>();
                expression.CreateMap<SubjectsBm, Subject>();
                expression.CreateMap<StudentBm, Student>();
                expression.CreateMap<Teacher, TeacherBm>()
                    .ForMember(emp => emp.UserName,
                    map => map.MapFrom(p => p.User.UserName)); ;
            });
        }
    }
}