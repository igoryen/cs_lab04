// 10. defines UserManager, RoleManager
// 20. identity role
using myAppMemory.Models;
using Microsoft.AspNet.Identity; // 10
using Microsoft.AspNet.Identity.EntityFramework; // 20
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace myAppMemory.Models {
  public class Initiallizer : DropCreateDatabaseAlways<DataContext> {

    //===================================================
    // InitializeTables()
    //===================================================
    private void InitializeTables(DataContext dc){
      //-------------------------------------
      // #1 - initialize a few student rows
      // 10. create a student row
      // 20. assign all the basic info to the student
      // 30. assign 1/more courses to the student
      // 40. add the student row to table Students
      // 50. add the student row to table Students of course 1
      // 55. add the student row to table Students in course 2
      // 60. purge student row
      //-------------------------------------
      Student bob = new Student(); // 10
      bob.Id = 1; // 20
      bob.FirstName = "Bob";
      bob.LastName = "Smith";
      bob.Phone = "555-555-5555";
      bob.StudentNumber = "011111111";
      dc.Students.Add(bob);

      Student mary = new Student();
      mary.Id = 2;
      mary.FirstName = "Mary";
      mary.LastName = "Brown";
      mary.Phone = "555-555-5555";
      mary.StudentNumber = "011111112";
      dc.Students.Add(mary);

      Student wei = new Student();
      wei.Id = 3;
      wei.FirstName = "Wei";
      wei.LastName = "Chen";
      wei.Phone = "555-555-5555";
      wei.StudentNumber = "011111113";
      dc.Students.Add(wei);

      Student john = new Student("John", "Woo", "555-555-1234", "011111114");
      john.Id = 4;
      dc.Students.Add(john);

      Student jack = new Student("Jack", "Smith", "555-555-1235", "011111115");
      jack.Id = 5;
      dc.Students.Add(jack);

      Student jill = new Student("Jill", "Smith", "555-555-1236", "011111116");
      jack.Id = 6;
      dc.Students.Add(jill);
      

      //-------------------------------------
      // #2 - initialize a few course rows
      // 60. insert rows into table Courses
      //-------------------------------------
      Course int422 = new Course();
      int422.CourseCode = "INT422";
      int422.CourseName = "Windows Web Programming";
      dc.Courses.Add(int422);


      Course jac444 = new Course();
      jac444.CourseName = "Java";
      jac444.CourseCode = "JAC444";
      dc.Courses.Add(jac444);


      Course abc123 = new Course();
      jac444.CourseName = "Preschool English";
      jac444.CourseCode = "ABC123";
      dc.Courses.Add(abc123);

      Course and123 = new Course();
      jac444.CourseName = "Android Basics";
      jac444.CourseCode = "MAND123";
      dc.Courses.Add(and123);

      Course rub123 = new Course();
      jac444.CourseName = "Ruby Basics";
      jac444.CourseCode = "RUB123";
      dc.Courses.Add(rub123);

      Course rus123 = new Course();
      jac444.CourseName = "Russian Basics";
      jac444.CourseCode = "RUS123";
      dc.Courses.Add(rus123);

      // 60
      //-------------------------------------
      // #3 - assign a set of courses to each student
      //-------------------------------------
      bob.Courses = new List<Course>();
      bob.Courses.Add(int422);
      bob.Courses.Add(jac444);
      bob.Courses.Add(abc123);
      dc.Students.Add(bob);

      mary.Courses = new List<Course>();
      mary.Courses.Add(jac444);
      mary.Courses.Add(abc123);
      mary.Courses.Add(and123);
      dc.Students.Add(mary);

      wei.Courses = new List<Course>();
      wei.Courses.Add(abc123);
      wei.Courses.Add(and123);
      wei.Courses.Add(rub123);
      dc.Students.Add(wei);

      john.Courses = new List<Course>();
      john.Courses.Add(and123);
      john.Courses.Add(rub123);
      john.Courses.Add(rus123);
      dc.Students.Add(john);

      jack.Courses = new List<Course>();
      jack.Courses.Add(rub123);
      jack.Courses.Add(rus123);
      jack.Courses.Add(int422);
      dc.Students.Add(jack);

      jill.Courses = new List<Course>();
      jill.Courses.Add(rus123);
      jill.Courses.Add(int422);
      jill.Courses.Add(jac444);
      dc.Students.Add(jill);
      
      // #4 - assign a set of students to each course

      int422.Students = new List<Student>();
      int422.Students.Add(bob);
      int422.Students.Add(jack);
      int422.Students.Add(jill);
      dc.Courses.Add(int422);

      jac444.Students = new List<Student>();
      jac444.Students.Add(bob);
      jac444.Students.Add(mary);
      jac444.Students.Add(jill);
      dc.Courses.Add(jac444);

      abc123.Students = new List<Student>();
      abc123.Students.Add(bob);
      abc123.Students.Add(mary);
      abc123.Students.Add(wei);
      dc.Courses.Add(abc123);

      and123.Students = new List<Student>();
      and123.Students.Add(mary);
      and123.Students.Add(wei);
      and123.Students.Add(john);
      dc.Courses.Add(and123);

      rub123.Students = new List<Student>();
      rub123.Students.Add(wei);
      rub123.Students.Add(john);
      rub123.Students.Add(jack);
      dc.Courses.Add(rub123);

      rus123.Students = new List<Student>();
      rus123.Students.Add(john);
      rus123.Students.Add(jack);
      rus123.Students.Add(jill);
      dc.Courses.Add(rus123);

      //-------------------------------------
      // #5 - initialize some faculties and assign to them courses
      //-------------------------------------
      Faculty peter = new Faculty("Peter", "McIntyre", "555-567-6789", "034234678"); // 20
      peter.Id = 10; // 25
      peter.Courses.Add(int422);
      peter.Courses.Add(jac444);
      dc.Faculties.Add(peter);

      Faculty adam = new Faculty("Adam", "Adamson", "555-567-6790", "034234677");
      adam.Id = 11;
      adam.Courses.Add(abc123);
      adam.Courses.Add(and123);
      dc.Faculties.Add(adam); // 35

      Faculty ron = new Faculty("Ronald", "Ronaldson", "555-567-6791", "034234676");
      ron.Id = 12;
      ron.Courses.Add(rub123);
      ron.Courses.Add(rus123);
      dc.Faculties.Add(ron); // 35

      //dc.Faculty.Add(fac);

      dc.SaveChanges(); // commit changes
    }

    //===================================================
    // InitianlizeIdentityForEF()
    //===================================================
    //private void InitializeIdentityForEF(MyDbContext context) {
    private void InitializeIdentityForEF(DataContext context) {

      var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
      var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
      var myinfo = new MyUserInfo() { FirstName = "Pranav", LastName = "Rastogi" };

      string name = "Admin";
      string password = "123456";
      string test = "test";

      //Create Role Test and User Test
      RoleManager.Create(new IdentityRole(test));
      UserManager.Create(new ApplicationUser() { UserName = test });

      //Create Role Admin if it does not exist
      if (!RoleManager.RoleExists(name)) {
        var roleresult = RoleManager.Create(new IdentityRole(name));
      }

      //Create User=Admin with password=123456
      var user = new ApplicationUser();
      user.UserName = name;
      user.HomeTown = "Seattle";
      user.MyUserInfo = myinfo;
      var adminresult = UserManager.Create(user, password);

      //Add User Admin to Role Admin
      if (adminresult.Succeeded) {
        var result = UserManager.AddToRole(user.Id, name);
      }
    }

    protected override void Seed(DataContext dc) {
      InitializeIdentityForEF(dc);
      InitializeTables(dc);
      base.Seed(dc);
    }


    public List<Student> Students { get; set; }
    public List<Faculty> Faculties { get; set; }
    public List<Course> Courses { get; set; }
  }
}
