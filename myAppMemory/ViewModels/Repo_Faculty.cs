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
    public FacultyPublic getFacultyPublic(int? id) {
      var fa = Faculties.FirstOrDefault(n => n.Id == id);
      FacultyPublic fac = new FacultyPublic();
      fac.FirstName = fa.FirstName;
      fac.LastName = fa.LastName;
      fac.Phone = fa.Phone;
      fac.StudentNumber = fa.StudentNumber;
      return fac;
    }


    // return a list / collection of faculties


    public List<Faculty> Faculties { get; set; }
  }
}