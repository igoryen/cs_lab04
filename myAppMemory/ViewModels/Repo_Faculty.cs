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
    public FacultyFull createFaculty(FacultyFull fa) {
      Faculty fac = new Faculty(fa.FirstName, fa.LastName, fa.Phone);
      fac.Id = Faculties.Max(n => n.Id) + 1;
      Faculties.Add(fac);
      return fa;
    }

    // return single faculty row by id


    // return a list / collection of faculties


    public List<Faculty> Faculties { get; set; }
  }
}