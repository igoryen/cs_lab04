using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace myAppMemory.Models {
  public class Initiallizer {
    public Initiallizer() {
      this.Students = new List<Student>();

      Student student = new Student();
      student.Id = 1;
      student.FirstName = "Bob";
      student.LastName = "Smith";
      student.Phone = "555-555-5555";
      student.StudentNumber = "011111111";

      Students.Add(student);
      student = null;

      student = new Student();
      student.Id = 2;
      student.FirstName = "Mary";
      student.LastName = "Brown";
      student.Phone = "555-555-5555";
      student.StudentNumber = "011111112";

      Students.Add(student);
      student = null;

      student = new Student();
      student.Id = 3;
      student.FirstName = "Wei";
      student.LastName = "Chen";
      student.Phone = "555-555-5555";
      student.StudentNumber = "011111113";

      Students.Add(student);
      student = null;

      student = new Student("John", "Woo", "555-555-1234", "011111114");
      student.Id = 4;

      Students.Add(student);

    }

    public List<Student> Students { get; set; }
  }
}