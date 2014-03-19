// 10. defines UserManager, RoleManager
// 20. identity role
// 45. for HttpStatusCode
// 50. for Task<>
using Microsoft.AspNet.Identity; // 10
using Microsoft.AspNet.Identity.EntityFramework; // 20
using myAppMemory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net; // 45
using System.Threading.Tasks; // 50
using System.Web;
using System.Web.Mvc;

namespace myAppMemory.Controllers {
  public class MessagesController : Controller {
    private DataContext dc;
    private UserManager<ApplicationUser> manager;


    // Methods alphabetically

    // A

    //===================================================
    // All() - GET: /Messages/All
    // 10. this route is locked for all but Admin
    //===================================================
    [Authorize(Roles = "Admin")] // 10
    public async Task<ActionResult> All() {
      return View(await dc.Messages.ToListAsync());
    }

    // C

    //===================================================
    // MessagesController() - contstructor
    //===================================================
    public MessagesController() {
      dc = new DataContext();
      manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dc));
    }

    //===================================================
    // Create() - GET: /Messages/Create
    //===================================================
    public ActionResult Create() {
      return View();
    }

    //===================================================
    // Create() - POST: /Messages/Create
    // 20. Include = "Id, Body", but not "User"
    //===================================================
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind(Include = "Id,Body")] Message message) { // 20
      var currentUser = await manager.FindByIdAsync(User.Identity.GetUserId());
      if (ModelState.IsValid) {
        message.User = currentUser;
        dc.Messages.Add(message);
        await dc.SaveChangesAsync();
        return RedirectToAction("Index");
      }

      return View(message);
    }



    // D

    //===================================================
    // Delete() - GET: /Messages/Delete/5
    //===================================================
    public async Task<ActionResult> Delete(int? id) {
      var currentUser = await manager.FindByIdAsync(User.Identity.GetUserId());
      if (id == null) {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Message message = await dc.Messages.FindAsync(id);
      if (message == null) {
        return HttpNotFound();
      }
      if (message.User.Id != currentUser.Id) {
        return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
      }
      return View(message);
    }

    //===================================================
    // Delete() - POST: /Messages/Delete/5
    //===================================================
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(int id) {
      Message message = await dc.Messages.FindAsync(id);
      dc.Messages.Remove(message);
      await dc.SaveChangesAsync();
      return RedirectToAction("Index");
    }

    //===================================================
    // Details() - GET: /Messages/Details/5
    //===================================================
    public async Task<ActionResult> Details(int? id) {
      var currentUser = await manager.FindByIdAsync(User.Identity.GetUserId());
      if (id == null) {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Message message = await dc.Messages.FindAsync(id);
      if (message == null) {
        return HttpNotFound();
      }
      if (message.User.Id != currentUser.Id) {
        return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
      }
      return View(message);
    }

    //===================================================
    // Dispose()
    //===================================================
    protected override void Dispose(bool disposing) {
      if (disposing) {
        dc.Dispose();
      }
      base.Dispose(disposing);
    }

    // E

    //===================================================
    // Edit() - GET: /Messages/Edit/5
    //===================================================
    public async Task<ActionResult> Edit(int? id) {
      var currentUser = await manager.FindByIdAsync(User.Identity.GetUserId());
      if (id == null) {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Message message = await dc.Messages.FindAsync(id);
      if (message == null) {
        return HttpNotFound();
      }
      if (message.User.Id != currentUser.Id) {
        return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
      }
      return View(message);
    }

    //===================================================
    // Edit() - POST: /Messages/Edit/5
    //===================================================
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit([Bind(Include = "Id,Body")] Message message) {
      if (ModelState.IsValid) {
        dc.Entry(message).State = EntityState.Modified;
        await dc.SaveChangesAsync();
        return RedirectToAction("Index");
      }
      return View(message);
    }


    // I

    //===================================================
    // Index() - GET: /Messages/
    //===================================================
    public ActionResult Index() {
      var currentUser = manager.FindById(User.Identity.GetUserId());
      return View(dc.Messages.ToList().Where(message => message.User.Id == currentUser.Id));
    }



  }
}
