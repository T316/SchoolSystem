[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(SchoolSystem.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(SchoolSystem.Web.App_Start.NinjectWebCommon), "Stop")]

namespace SchoolSystem.Web.App_Start
{
    using System;
    using System.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using SchoolSystem.Services.Interfaces.SchoolDiary;
    using SchoolSystem.Services.SchoolDiary;
    using SchoolSystem.Services.Interfaces.DirectorPanel;
    using SchoolSystem.Services.DirectorPanel;
    using SchoolSystem.Data;
    using SchoolSystem.Data.Interfaces;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ITeacherService>().To<TeacherService>();
            kernel.Bind<IGradesService>().To<GradesService>();
            kernel.Bind<IStudentsService>().To<StudentsService>();
            kernel.Bind<ISubjectsService>().To<SubjectsService>();
            kernel.Bind<IDirectorTeachersService>().To<DirectorTeachersService>();
            kernel.Bind<IDirectorGradesService>().To<DirectorGradesService>();
            kernel.Bind<IDirectorStudentsService>().To<DirectorStudentsService>();
            kernel.Bind<IDirectorSubjectsService>().To<DirectorSubjectsService>();
            kernel.Bind<ISchoolSystemContext>().To<SchoolSystemContext>();
        }        
    }
}
