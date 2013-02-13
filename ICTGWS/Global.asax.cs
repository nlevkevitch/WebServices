using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
 
// new...
using AutoMapper;
using System.Web.Http.Validation.Providers;

namespace ICTGWS
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
           
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Add the authorization handler to the app
            GlobalConfiguration.Configuration.MessageHandlers.Add
                (new Handlers.OAuth2MessageHandler());
            // Store initializer
         
          // System.Data.Entity.Database.SetInitializer(new ICTGWS.Models.StoreInitializer());
           GlobalConfiguration.Configuration.Services.RemoveAll(typeof(System.Web.Http.Validation.ModelValidatorProvider),v => v is InvalidModelValidatorProvider);

            // AutoMapper maps
            Mapper.CreateMap<ViewModels.ProgramAdd, Models.Program>();
            Mapper.CreateMap<Models.Program, ViewModels.ProgramAdd>();

            Mapper.CreateMap<ViewModels.ProgramsGet, Models.Program>();
            Mapper.CreateMap<Models.Program, ViewModels.ProgramsGet>();

            Mapper.CreateMap<ViewModels.ProgramGetWithSubjects, Models.Program>();
            Mapper.CreateMap<Models.Program, ViewModels.ProgramGetWithSubjects>();

            Mapper.CreateMap<ViewModels.ProgramsForList, Models.Program>();
            Mapper.CreateMap <Models.Program, ViewModels.ProgramsForList>();

            Mapper.CreateMap<ViewModels.ProgramUpdate, Models.Program>();
            Mapper.CreateMap<Models.Program, ViewModels.ProgramUpdate>();

            Mapper.CreateMap<ViewModels.ProgramDelete, Models.Program>();
            Mapper.CreateMap<Models.Program, ViewModels.ProgramDelete>();

            Mapper.CreateMap<ViewModels.SubjectAdd, Models.Subject>();
            Mapper.CreateMap<Models.Subject, ViewModels.SubjectAdd>();

            Mapper.CreateMap<ViewModels.SubjectsGet, Models.Subject>();
            Mapper.CreateMap<Models.Subject, ViewModels.SubjectsGet>();

            Mapper.CreateMap<ViewModels.SubjectGetWithPrograms, Models.Subject>();
            Mapper.CreateMap<Models.Subject, ViewModels.SubjectGetWithPrograms>();

            Mapper.CreateMap<ViewModels.SubjectsForList, Models.Subject>();
            Mapper.CreateMap<Models.Subject, ViewModels.SubjectsForList>();

            Mapper.CreateMap<ViewModels.SubjectUpdate, Models.Subject>();
            Mapper.CreateMap<Models.Subject, ViewModels.SubjectUpdate>();

            Mapper.CreateMap<ViewModels.SubjectDelete, Models.Subject>();
            Mapper.CreateMap<Models.Subject, ViewModels.SubjectDelete>();

            Mapper.CreateMap<ViewModels.EmployeeAdd, Models.Employee>();
            Mapper.CreateMap<Models.Employee, ViewModels.EmployeeAdd>();

            Mapper.CreateMap<Models.Employee, ViewModels.EmployeesGet>();
            Mapper.CreateMap<ViewModels.EmployeesGet, Models.Employee>();

            Mapper.CreateMap<ViewModels.EmployeesForList, Models.Employee>();
            Mapper.CreateMap<Models.Employee, ViewModels.EmployeesForList>();

            Mapper.CreateMap<ViewModels.EmployeeUpdate, Models.Employee>();
            Mapper.CreateMap<Models.Employee, ViewModels.EmployeeUpdate>();

            Mapper.CreateMap<ViewModels.EmployeeDelete, Models.Employee>();
            Mapper.CreateMap<Models.Employee, ViewModels.EmployeeDelete>();

            Mapper.CreateMap<ViewModels.CourseAdd, Models.Course>();
            Mapper.CreateMap<Models.Course, ViewModels.CourseAdd>();

            Mapper.CreateMap<ViewModels.CoursesGet, Models.Course>();
            Mapper.CreateMap<Models.Course, ViewModels.CoursesGet>();

            Mapper.CreateMap<Models.Course, ViewModels.CourseGetWithStudents>();
            Mapper.CreateMap<ViewModels.CourseGetWithStudents, Models.Course>();

            Mapper.CreateMap<Models.Course, ViewModels.CourseGetWithGradedWorks>();
            Mapper.CreateMap<ViewModels.CourseGetWithGradedWorks, Models.Course>();

            Mapper.CreateMap<ViewModels.CoursesForList, Models.Course>();
            Mapper.CreateMap<Models.Course, ViewModels.CoursesForList>();

            Mapper.CreateMap<ViewModels.CourseDelete, Models.Course>();
            Mapper.CreateMap<Models.Course, ViewModels.CourseDelete>();

            Mapper.CreateMap<ViewModels.CourseUpdate, Models.Course>();
            Mapper.CreateMap<Models.Course, ViewModels.CourseUpdate>();

            Mapper.CreateMap<ViewModels.CourseDelete, Models.Course>();
            Mapper.CreateMap<Models.Course, ViewModels.CourseDelete>();

            Mapper.CreateMap<ViewModels.GradedWorkAdd, Models.GradedWork>();
            Mapper.CreateMap<Models.GradedWork, ViewModels.GradedWorkAdd>();

            Mapper.CreateMap<Models.GradedWork, ViewModels.GradedWorksGet>();
            Mapper.CreateMap<ViewModels.GradedWorksGet, Models.GradedWork>();

            Mapper.CreateMap<ViewModels.GradedWorksForList, Models.GradedWork>();
            Mapper.CreateMap<Models.GradedWork, ViewModels.GradedWorksForList>();

            Mapper.CreateMap<ViewModels.GradedWorkUpdate, Models.GradedWork>();
            Mapper.CreateMap<Models.GradedWork, ViewModels.GradedWorkUpdate>();

            Mapper.CreateMap<ViewModels.GradedWorkDelete, Models.GradedWork>();
            Mapper.CreateMap<Models.GradedWork, ViewModels.GradedWorkDelete>();

            Mapper.CreateMap<ViewModels.SemesterAdd, Models.Semester>();
            Mapper.CreateMap<Models.Semester, ViewModels.SemesterAdd>();

            Mapper.CreateMap<ViewModels.SemestersGet, Models.Semester>();
            Mapper.CreateMap<Models.Semester, ViewModels.SemestersGet>();

            Mapper.CreateMap<ViewModels.SemesterWithCourses, Models.Semester>();
            Mapper.CreateMap<Models.Semester, ViewModels.SemesterWithCourses>();

            Mapper.CreateMap<ViewModels.SemestersForList, Models.Semester>();
            Mapper.CreateMap<Models.Semester, ViewModels.SemestersForList>();

            Mapper.CreateMap<ViewModels.SemesterUpdate, Models.Semester>();
            Mapper.CreateMap<Models.Semester, ViewModels.SemesterUpdate>();

            Mapper.CreateMap<ViewModels.StudentAdd, Models.Student>();
            Mapper.CreateMap<Models.Student, ViewModels.StudentAdd>();

            Mapper.CreateMap<ViewModels.StudentsGet, Models.Student>();
            Mapper.CreateMap<Models.Student, ViewModels.StudentsGet>();

            Mapper.CreateMap<ViewModels.StudentGetWithCourses, Models.Student>();
            Mapper.CreateMap<Models.Student, ViewModels.StudentGetWithCourses>();

            Mapper.CreateMap<ViewModels.StudentsForList, Models.Student>();
            Mapper.CreateMap<Models.Student, ViewModels.StudentsForList>();

            Mapper.CreateMap<ViewModels.StudentUpdate, Models.Student>();
            Mapper.CreateMap<Models.Student, ViewModels.StudentUpdate>();

            Mapper.CreateMap<ViewModels.StudentDelete, Models.Student>();
            Mapper.CreateMap<Models.Student, ViewModels.StudentDelete>();
        }
    }
}