﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myAppMemory.ViewModels; // 7

namespace myAppMemory.Controllers {
  public class VMController : Controller {
    private Repo_Student rs = new Repo_Student(); // 10
    //
    // GET: /VM/
    public ActionResult Index() { // 20

      //ViewBag.id = 1;

      return View(rs.getStudentNames()); // 30 
    }

    public ActionResult Create() { // 40
      return View();
    }
    [HttpPost]
    public ActionResult Create(StudentFull st) { // 50
      if (ModelState.IsValid) { 
        rs.createStudent(st);
        return RedirectToAction("Index");
      }
      else { // 60
        return View("Error");
      }
    }

    public ActionResult Details(int? id) { // 70
      return View(rs.getStudentPublic(id)); // 80
    }

    public ActionResult Error() {
      return View();
    }
  }
}

/* 7. using folder ViewModels (its classes):
 *   Repo_Students.cs
 *   StudentName.cs
 *   VM_Student.cs
*/ 

// Index()
/* 30. a. Go to ViewModels/Repo_Student.cs
 *     b. Call getStudentNames()
 *     c. Send its retval to Views/VM/Index.cshtml [the eponymous view]
 */

// Details()
/* 70. take the id which is passed from the Views/VM/Details.cshtml
 * 80. a. Go to ViewModels/Repo_Student.cs
 *     b. call getStudentPublic(id) using the id
 *     c. Send its retval to Views/VM/Details.cshtml [the eponymous view]
 * 
 */