using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myAppMemory.Models;

namespace myAppMemory.ViewModels {
  public class Repo_Faculty {

    public Repo_Faculty() {
      this.Faculties = (List<Faculty>)HttpContext.Current.Application["Faculties"];
    }

    // create a Faculty record


    // return single faculty row by id


    // return a list / collection of faculties
  }
}