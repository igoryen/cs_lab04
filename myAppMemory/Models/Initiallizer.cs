using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace myAppMemory.Models {
  public class Initiallizer /*: DropCreateDatabaseAlways<DataContext>*/ {
    //protected override void Seed(DataContext dc) {
    public Initiallizer(){

      this.Students = new List<Student>(); // 10

      Course int422 = new Course(); // 15
      int422.CourseCode = "INT422";
      int422.CourseName = "Windows Web Programming";


      Course jac444 = new Course(); // 15
      jac444.CourseName = "Java";
      jac444.CourseCode = "JAC444";


      Student student = new Student(); // 20
      student.Id = 1;
      student.FirstName = "Bob";
      student.LastName = "Smith";
      student.Phone = "555-555-5555";
      student.StudentNumber = "011111111";
      student.Courses.Add(jac444);  // 30
      student.Courses.Add(int422);

      //dc.Students.Add(student);
      Students.Add(student); // 35
      int422.Students.Add(student); // 40
      jac444.Students.Add(student);
      student = null; // 45


      student = new Student();
      student.Id = 2;
      student.FirstName = "Mary";
      student.LastName = "Brown";
      student.Phone = "555-555-5555";
      student.StudentNumber = "011111112";
      student.Courses.Add(jac444);
      student.Courses.Add(int422);

      //dc.Students.Add(student);
      Students.Add(student);
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

      //dc.Students.Add(student);
      Students.Add(student); 
      int422.Students.Add(student);
      jac444.Students.Add(student);
      student = null;


      student = new Student("John", "Woo", "555-555-1234", "011111114");
      student.Id = 4;
      student.Courses = new List<Course>();
      student.Courses.Add(jac444);
      student.Courses.Add(int422);

      //dc.Students.Add(student);
      Students.Add(student);
      int422.Students.Add(student);
      jac444.Students.Add(student);

      //dc.Courses.Add(int422);
      //dc.Courses.Add(jac444);

      //------------------------------------

      Faculty faculty = new Faculty(); // 100
      this.Faculties = new List<Faculty>();
      faculty.Courses = new List<Course>(); // 110

      faculty = new Faculty("Peter", "McIntyre", "555-567-6789", "034234678"); // 105
      faculty.Id = 10;
      faculty.Courses.Add(jac444); // 115
      faculty.Courses.Add(int422);
      Faculties.Add(faculty);

      faculty = new Faculty("John", "Johnson", "555-567-6790", "034234677"); // 105
      faculty.Id = 11;
      faculty.Courses.Add(jac444); // 115
      faculty.Courses.Add(int422);
      Faculties.Add(faculty);

      faculty = new Faculty("Jacob", "Jacobson", "555-567-6791", "034234676"); // 105
      faculty.Id = 12;
      faculty.Courses.Add(jac444); // 115
      faculty.Courses.Add(int422);
      Faculties.Add(faculty);

      //dc.Faculty.Add(fac);
      //dc.SaveChanges();

    }

    public List<Student> Students { get; set; }
    public List<Faculty> Faculties { get; set; }
    public List<Course> Courses { get; set; }
  }
}
/*
 * 10. make a "Students" table
 * 
 * 15. make a "Course" row and fill it out
 * 
 * 20. make a "Student" row and fill it out
 * 30. fill out the "Student" row's "Courses" sub-column with 2 "Course" rows 
 * 35. to the "Students" table: add the "Student" row 
 * 40. to the "Course" row's "Students" sub-table: add the "Student" row  
 * 45. empty the "Student" row
 * 
 * 100. make a "Faculty" row
 * 105. fill out the "Faculty" row
 * 110. in the "Faculty" row's "Courses" subtable: make a new "Courses" sub-table
 * 115. to the "Faculty" row's "Courses" subtable: add a new "Course" row
 */