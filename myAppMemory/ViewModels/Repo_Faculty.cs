using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myAppMemory.Models;
using myAppMemory.ViewModels;

namespace myAppMemory.ViewModels {
  public class Repo_Faculty {

    public Repo_Faculty() {
      this.Faculties = (List<Faculty>)HttpContext.Current.Application["Faculties"];
    }

    // create a Faculty record
    public FacultyFull createFaculty(FacultyFull fa) {
      Faculty fac = new Faculty(fa.FirstName, fa.LastName, fa.Phone, fa.FacultyNumber);
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
      fac.FacultyNumber = fa.FacultyNumber;
      return fac;
    }


    // return a list / collection of faculties
    public IEnumerable<FacultyPublic> getFacultiesPublic() { // 1
      var ls = Faculties.OrderBy(n => n.FacultyId); // 20
      List<FacultyPublic> rls = new List<FacultyPublic>(); // 25

      foreach (var item in ls) {  // 30
        FacultyPublic row = new FacultyPublic();   // 35

        row.FacultyNumber = item.FacultyId;  // 40 
        row.FirstName = item.FirstName;
        row.LastName = item.LastName;
        row.Phone = item.Phone;

        rls.Add(row);  // 45 
      }
      return rls;  // 50
    }


    public List<Faculty> Faculties { get; set; }
  }
}