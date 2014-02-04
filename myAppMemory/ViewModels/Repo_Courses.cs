using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myAppMemory.ViewModels {
  public class Repo_Courses : RepositoryBase {

    public static List<CourseForList> getCourseForList(List<myAppMemory.Models.Course> ls) {
      List<CourseForList> nls = new List<CourseForList>();

      foreach (var item in ls) {
        CourseForList co = new CourseForList();
        co.CourseCode = item.CourseCode;
        co.CourseId = item.Id;
        nls.Add(co);
      }

      return nls;
    }
  }
}