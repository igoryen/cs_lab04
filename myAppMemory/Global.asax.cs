using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using myAppMemory.Models;
using AutoMapper;

namespace myAppMemory {
  public class MvcApplication : System.Web.HttpApplication {
    protected void Application_Start() {
      AreaRegistration.RegisterAllAreas();
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);

      System.Data.Entity.Database.SetInitializer(new myAppMemory.Models.Initiallizer());

      
      /*
      Initiallizer si = new Initiallizer();
      Application["Students"] = si.Students;
      Application["Faculties"] = si.Faculties;
      Application["Courses"] = si.Courses;
      */

      // to ViewModels/classes

      Mapper.CreateMap<Models.Course, ViewModels.CourseBase>();
      Mapper.CreateMap<Models.Course, ViewModels.CourseFull>();

      Mapper.CreateMap<Models.Faculty, ViewModels.FacultyBase>();
      Mapper.CreateMap<Models.Faculty, ViewModels.FacultyFull>();

      Mapper.CreateMap<Models.Student, ViewModels.StudentBase>();
      Mapper.CreateMap<Models.Student, ViewModels.StudentFull>();
      

      // from ViewModels/classes

      Mapper.CreateMap<ViewModels.CourseBase, Models.Course>();
      Mapper.CreateMap<ViewModels.CourseFull, Models.Course>();

      Mapper.CreateMap<ViewModels.FacultyBase, Models.Faculty>();
      Mapper.CreateMap<ViewModels.FacultyFull, Models.Faculty>();

      Mapper.CreateMap<ViewModels.StudentBase, Models.Student>();
      Mapper.CreateMap<ViewModels.StudentFull, Models.Student>();


    }
  }
}
