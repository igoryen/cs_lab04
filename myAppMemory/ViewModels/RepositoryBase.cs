using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myAppMemory.ViewModels;
using myAppMemory.Models;

namespace myAppMemory.ViewModels {

  public class RepositoryBase {

    protected DataContext dc;

    public RepositoryBase() {

      dc = new DataContext();

      dc.Configuration.ProxyCreationEnabled = false; // 20

      dc.Configuration.LazyLoadingEnabled = false; // 25
    }
  }
}

/*
 * 20. Turn off the Entity Framework (EF) proxy creation features
       We do NOT want the EF to track changes - we'll do that ourselves
 * 25. Also, turn off lazy loading...
       We want to retain control over fetching related objects
 */