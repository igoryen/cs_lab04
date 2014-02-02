using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using myAppMemory.Models;

namespace myAppMemory.ViewModels {
  public class Repo_Student {
    public Repo_Student() {
      this.Students = (List<Student>)HttpContext.Current.Application["Students"];
    }

    public IEnumerable<StudentsForList> getForList() {
      var ls = this.Students.OrderBy(n => n.Id);

      List<StudentsForList> rls = new List<StudentsForList>();

      foreach (var item in ls) {
        StudentsForList stu = new StudentsForList();
        stu.StudentId = item.Id;
        stu.StudentNumber = item.StudentNumber;
        rls.Add(stu);
      }

      return rls;
    }

    public StudentPublic getStudentPublic(int? id) {
      var st = Students.FirstOrDefault(n => n.Id == id);

      StudentPublic stu = new StudentPublic();
      stu.FirstName = st.FirstName;
      stu.LastName = st.LastName;
      stu.Phone = st.Phone;
      stu.StudentNumber = st.StudentNumber;

      return stu;

    }

    public IEnumerable<StudentPublic> getStudentsPublic() { // 1
      var ls = Students.OrderBy(n => n.StudentNumber); // 20
      List<StudentPublic> rls = new List<StudentPublic>(); // 25

      foreach (var item in ls) {  // 30
        StudentPublic row = new StudentPublic();   // 35
        
        row.StudentNumber = item.StudentNumber;  // 40 
        row.FirstName = item.FirstName;
        row.LastName = item.LastName;
        row.Phone = item.Phone;
        
        rls.Add(row);  // 45 
      }
      return rls;  // 50
    }

    public IEnumerable<StudentFull> getStudentsFull() { // 55
      
      var ls = this.Students.OrderBy(n => n.LastName);     // 60
      List<StudentFull> rls = new List<StudentFull>();   // 65

      foreach (var item in ls) {  // 70
        StudentFull row = new StudentFull();   // 75

        row.StudentId = item.Id;  // 80
        row.StudentNumber = item.StudentNumber;             
        row.FirstName = item.FirstName;
        row.LastName = item.LastName;
        row.Phone = item.Phone;

        rls.Add(row);  // 85
      }
      return rls; // 90
    }

    public IEnumerable<StudentName> getStudentNames() { // 95

      var ls = this.Students.OrderBy(n => n.LastName);    // 100
      List<StudentName> rls = new List<StudentName>();    // 105

      foreach (var item in ls) {      // 110
        StudentName row = new StudentName(); // 115

        row.StudentId = item.Id; // 50
        row.FirstName = item.FirstName;
        row.LastName = item.LastName;

        rls.Add(row); // 51 
      }
      return rls; // 52
    }


    //public IEnumerable<StudentPublic> getStudentsPublic()

    public StudentFull createStudent(StudentFull st) {
      Student stu = new Student(st.FirstName, st.LastName, st.Phone, st.StudentNumber);
      stu.Id = Students.Max(n => n.Id) + 1;
      Students.Add(stu);
      return st;
    }

    public List<Student> Students { get; set; }
  }
}
// getStudentsPublic()  -- gets a List of all Students, mapped to a List of StudentPublic objects, sorted by StudentNumber
/* 20. make a list of students ordered by StudentNo
 * 25. make an empty 4-column table "StudentPublic"
 * 30. loop through the list of students ordered by StudentNo
 * 35. make a 4-column row (StudentPublic)
 * 40. fill out the row's 4 columns with data from students list
 * 45. add the 4-column row StudentPublic to the 4-column table for StudentPublic's
 * 50. produce the filled out 4-column table of StudentPublic's 
 */

// getStudentsFull() -- gets a List of all Students, mapped to a List of StudentFull objects, sorted by LastName
/* 55. produce a 5-column table of students sorted by LastName
 * 60. make a list of students ordered by StudentNo
 * 65. make an empty 5-column table "StudentFull"
 * 70. loop through the list of students ordered by StudentNo
 * 75. make a 5-column row "StudentFull"
 * 80. fill out the row's 5 columns with data from students list
 * 85. add the 5-column row StudentPublic to the 5-column table "StudentFull"
 * 90. produce the filled out 5-column table "StudentFull" 
 */

// getStudentNames -- gets a List of all Students, mapped to a List of StudentName objects, sorted by LastName 
/* 45. take a table... ??? how to use it???
 * 46. make a list of students ordered by LastName. ls = list
 * 47. make a 3-column table "StudentName". rls = ready list
 * 48. loop through the list of students ordered by LastName
 * 49. make a 3-column table row "StudentName"
 * 50. fill out the 3-column table row
 * 51. add the StudentPublic to the list for StudentPublic's
 * 52. 
 */

