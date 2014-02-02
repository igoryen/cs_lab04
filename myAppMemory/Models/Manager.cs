using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace myAppMemory.Models {
  public class Manager {
    public Manager() {
      this.Students = (List<Student>)HttpContext.Current.Application["Students"];
    }

    public Student getStudent(int? id) {
      return Students.FirstOrDefault(n => n.Id == id);
    }

    public IEnumerable<Student> sortStudents() {
      return this.Students.OrderBy(n => n.Id);
    }

    public Student createStudent(Student stu) {
      //stu.Id = Students.Last().Id + 1;
      stu.Id = Students.Max(n => n.Id) + 1;
      Students.Add(stu);
      return stu;
    }

    public Student createStudent(string fName, string lName, string pNumber, string sid) {
      var st = new Student(fName, lName, pNumber, sid);
      st.Id = Students.Last().Id + 1;

      Students.Add(st);

      return st;
    }
    public Student editStudent(int id, string fName, string lName, string pNumber, string sid) {
      var stu = Students.FirstOrDefault(b => b.Id == id);

      stu.FirstName = fName;
      stu.LastName = lName;
      stu.Phone = pNumber;
      stu.StudentNumber = sid;

      return stu;
    }

    //this is essentailly a ViewModel because the SelectList only carries the data needed to display a list control
    //don't do this until week two.
    public SelectList getSelectList() {
      SelectList sl = new SelectList(Students, "Id", "StudentNumber");
      return sl;
    }


    public List<Student> Students { get; set; }
  }
}