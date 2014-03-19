using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myAppMemory.ViewModels;

namespace myAppMemory.Controllers {
  public class CourseController : Controller {
    
    private Repo_Course rc = new Repo_Course();
    private Repo_Student rs = new Repo_Student();
    private Repo_Faculty rf = new Repo_Faculty();


    // Action methods alphabetically

    // C
    
    //======================================
    // CourseCreate() - GET: /Course/Create
    //======================================
    public ActionResult CourseCreate() {
      ViewModels.CourseCreate newItem = new ViewModels.CourseCreate();

      ViewBag.students = rs.getStudentSelectList();
      ViewBag.faculties = rf.getFacultySelectList();

      return View("CourseCreate", newItem);
    }

    //======================================
    // CourseCreate() - POST: /Course/Create
    //======================================
    [HttpPost]
    public ActionResult CourseCreate(FormCollection form, ViewModels.CourseCreate newItem) {
      if (ModelState.IsValid) {
        try {
          if (form.Count == 4) {
            var addedItem = rc.amCreateCourse(newItem, form[3]);
            if (addedItem == null) { return View("Error");
            }
            else {
              return RedirectToAction("Details", new { Id = addedItem.CourseId });
            }
          } // if (form.Count == 4)
          return RedirectToAction("Index");
        } // try
        catch (Exception e) {
          ViewBag.ExceptionMessage = e.Message;
          return View("Error");
        } // catch
      } // if (ModelState.IsValid)
      else {
        return View("Error");
      }
    } // CourseCreate()

    //==================================================
    // Create() - GET: /Course/Create
    //==================================================
    public ActionResult Create() {
      ViewBag.students = rs.getStudentSelectList();
      ViewBag.faculties = rf.getFacultySelectList();
      return View();
    }
    //======================================
    // Create() - POST: /Course/Create
    // 10. 
    //======================================
    [HttpPost]
    public ActionResult Create(FormCollection form) {
      try {
        //if (form.Count == 5) { // 10
        //  rc.CreateCourse(form[1], form[2], form[3], form[4]);
        //}
        return RedirectToAction("Index");
      }
      catch(Exception e) {
        ViewBag.ExceptionMessage = e.Message;
        return View("Error");
      }
    }


    // - D -


    //==================================================
    // Delete() - GET: /Course/Delete/5
    // 10. if id == null, don't delete
    //==================================================
    public ActionResult Delete(int? id) {
      if (id == null) { // 10
        ViewBag.ExceptionMessage = "That was an invalid record";
        return View("Error");
      }

      var course = rc.amGetCourseFull(id);
      if (course == null) {
        ViewBag.ExceptionMessage = "That record could not be deleted because it doesn't exist";
        return View("Error");
      }
      return View(course);
    }

    //==================================================
    // Delete() - POST: /Course/Delete/5
    //==================================================
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id) {
      rc.DeleteCourse(id);
      return RedirectToAction("Index");
    }  

    //==================================================
    // Details() - GET: /Course/Details/5
    //==================================================
    public ActionResult Details(int id) {
      return View(rc.amGetCourseFull(id));
    }

    // E

    //==================================================
    // Edit() - // GET: /Course/Edit/5
    // 10. if id == null, do not query
    //==================================================
    public ActionResult Edit(int? id) {
      if (id == null) { // 10
        ViewBag.ExceptionMessage = "That was an invalid record";
        return View("Error");
      }
      var course = rc.amGetCourseFull(id);
      if (course == null) {
        ViewBag.ExceptionMessage = "That record could not be edited because it doesn't exist";
        return View("Error");
      }
      return View(course);
    } // Edit()

    //==================================================
    // Edit() - //POST: /Course/Edit/5
    // 10. If no ActionName("Edit"), it defaults to ActionName("Create")
    //==================================================
    [HttpPost, ActionName("Edit")] // 10
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id,CourseName,CourseCode")]ViewModels.CourseFull editItem) {

      if (ModelState.IsValid) {
        var newItem = rc.amEditCourse(editItem);
        if (newItem == null) {
          ViewBag.ExceptionMessage = "Record " + editItem.CourseId + " was not found.";
          return View("Error");
        }
        else {
          return RedirectToAction("Index");
        }
      } // if (ModelState.IsValid) 
      else {
        return View("Error");
      }
    } // Edit()

    // I

    //==================================================
    // Index() - GET: /Course/
    //==================================================
    public ActionResult Index() {
      return View(rc.amGetListOfCourseBase());
    }    

  }
}
