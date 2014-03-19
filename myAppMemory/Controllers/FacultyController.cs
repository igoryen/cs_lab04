using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myAppMemory.ViewModels;

namespace myAppMemory.Controllers {
  public class FacultyController : Controller {

    private Repo_Faculty rf = new Repo_Faculty();

    // C

    //======================================
    // Create() - GET: /Faculty/Create
    //======================================
    public ActionResult Create() {
      return View();
    }

    //======================================
    // Create(FormCollection collection) - POST: /Faculty/Create
    //======================================
    [HttpPost]
    public ActionResult Create(FormCollection collection) {
      try {
        // TODO: Add insert logic here

        return RedirectToAction("Index");
      }
      catch {
        return View();
      }
    }

    // D

    //======================================
    // Details() - GET: /Faculty/Details/5
    //======================================
    public ActionResult Details(int id) {
      return View(rf.amGetFacultyFull(id));
    }




    //======================================
    // Delete() - GET: /Faculty/Delete/5
    //======================================
    public ActionResult Delete(int id) {
      return View();
    }


    //======================================
    // Delete() - POST: /Faculty/Delete/5
    //======================================
    [HttpPost]
    public ActionResult Delete(int id, FormCollection collection) {
      try {
        // TODO: Add delete logic here

        return RedirectToAction("Index");
      }
      catch {
        return View();
      }
    }

    //======================================
    // Edit() - GET: /Faculty/Edit/5
    //======================================
    public ActionResult Edit(int id) {
      return View();
    }

    //======================================
    // Edit() - POST: /Faculty/Edit/5
    //======================================
    [HttpPost]
    public ActionResult Edit(int id, FormCollection collection) {
      try {
        // TODO: Add update logic here

        return RedirectToAction("Index");
      }
      catch {
        return View();
      }
    }

    // I

    //======================================
    // Index() - GET: /Faculty/
    //======================================
    public ActionResult Index() {
      //ViewBag.facs = rf.sortFaculties(); // 20
      //return View();
      return View(rf.getFacultyNames());
    }

    // V

    //======================================
    // View()
    //======================================
    /*private ActionResult View(FacultyPublic facultyPublic) {
      throw new NotImplementedException();
    }*/





  }
}
