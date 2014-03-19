using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myAppMemory.Models;
using myAppMemory.ViewModels;


namespace myAppMemory.Controllers {
  public class HomeController : Controller {
    private Manager man = new Manager(); // 10
    private Repo_Student rs = new Repo_Student();
    //
    // GET: /Home/

    public ActionResult Index() {
      //ViewBag.stu = man.sortStudents(); // 20
      ViewBag.stu = rs.getStudentNames();
      return View();
    }

    public ActionResult ViewAll() {
      return View(man.sortStudents()); // 30
    }

    public ActionResult Create() {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Student student) {
      if (ModelState.IsValid) // 50
              {
        man.createStudent(student);
        return RedirectToAction("ViewAll");
      }
      else {
        return View("Error");
      }
    }

    public ActionResult Ddl() {
      ViewBag.li = man.getSelectList(); // 60
      return View();
    }

    [HttpPost]
    public ActionResult Details(FormCollection form) {
      int id = Convert.ToInt32(form[0]);
      return View(man.getStudent(id));
    }

    public ActionResult Error() {
      return View(); ;
    }

  }
}

// 10. Materialize/make a manager

// Index()
/* 20. call Manager.cs/sortStudents(); store the retval in a var; put it into the ViewBag
 */

// ViewAll()
/* 30. == #20?
 */

// Create(Student student)
/* 50. 
 * 
 */

// Ddl()
/* 60. == #20
 */