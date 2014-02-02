using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using myAppMemory.Models;

namespace myAppMemory.Controllers
{
      public class HomeController : Controller
      {
          private Manager man = new Manager();
          //
          // GET: /Home/

          public ActionResult Index()
          {
              ViewBag.stu = man.sortStudents();
              return View();
          }

          public ActionResult ViewAll()
          {
              return View(man.sortStudents());
          }

          public ActionResult Create()
          {
              return View();
          }

          [HttpPost]
          public ActionResult Create(Student student)
          {
              if (ModelState.IsValid)
              {
                  man.createStudent(student);
                  return RedirectToAction("ViewAll");
              }
              else
              {
                  return View("Error");
              }
          }

          public ActionResult Ddl()
          {
              ViewBag.li = man.getSelectList();
              return View();
          }

          [HttpPost]
          public ActionResult Details(FormCollection form)
          {
              int id = Convert.ToInt32(form[0]);
              return View(man.getStudent(id));
          }

          public ActionResult Error()
          {
              return View(); ;
          }

      }
  }