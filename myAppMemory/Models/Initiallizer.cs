using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace myAppMemory.Models {
  public class Initiallizer : DropCreateDatabaseAlways<DataContext> {
    protected override void Seed(DataContext dc) {

      Course int422 = new Course();
      int422.CourseCode = "INT422";
      int422.CourseName = "Windows Web Programming";


      Course jac444 = new Course();
      jac444.CourseName = "Java";
      jac444.CourseCode = "JAC444";

      Faculty fac = new Faculty();

      Student student = new Student();
      student.Id = 1;
      student.FirstName = "Bob";
      student.LastName = "Smith";
      student.Phone = "555-555-5555";
      student.StudentNumber = "011111111";
      student.Courses.Add(jac444);
      student.Courses.Add(int422);

      dc.Students.Add(student);
      int422.Students.Add(student);
      jac444.Students.Add(student);
      student = null;


      student = new Student();
      student.Id = 2;
      student.FirstName = "Mary";
      student.LastName = "Brown";
      student.Phone = "555-555-5555";
      student.StudentNumber = "011111112";
      student.Courses.Add(jac444);
      student.Courses.Add(int422);

      dc.Students.Add(student);
      int422.Students.Add(student);
      jac444.Students.Add(student);
      student = null;


      student = new Student();
      student.Id = 3;
      student.FirstName = "Wei";
      student.LastName = "Chen";
      student.Phone = "555-555-5555";
      student.StudentNumber = "011111113";
      student.Courses.Add(jac444);
      student.Courses.Add(int422);

      dc.Students.Add(student);
      int422.Students.Add(student);
      jac444.Students.Add(student);
      student = null;


      student = new Student("John", "Woo", "555-555-1234", "011111114");
      student.Id = 4;
      student.Courses = new List<Course>();
      student.Courses.Add(jac444);
      student.Courses.Add(int422);

      dc.Students.Add(student);
      int422.Students.Add(student);
      jac444.Students.Add(student);

      dc.Courses.Add(int422);
      dc.Courses.Add(jac444);

      //------------------------------------

      fac = new Faculty("Peter", "McIntyre", "555-567-6789", "034234678");
      fac.Courses = new List<Course>();
      fac.Courses.Add(jac444);
      fac.Courses.Add(int422);
      dc.Faculty.Add(fac);

      dc.SaveChanges();

    }

  }
}