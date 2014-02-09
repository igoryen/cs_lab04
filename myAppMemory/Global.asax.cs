﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using myAppMemory.Models;

namespace myAppMemory {
  public class MvcApplication : System.Web.HttpApplication {
    protected void Application_Start() {
      AreaRegistration.RegisterAllAreas();
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);

      //System.Data.Entity.Database.SetInitializer(new myAppMemory.Models.Initiallizer());
      Initiallizer si = new Initiallizer();
      Application["Students"] = si.Students;
      Application["Faculties"] = si.Faculties;
      Application["Courses"] = si.Courses;
    }
  }
}
