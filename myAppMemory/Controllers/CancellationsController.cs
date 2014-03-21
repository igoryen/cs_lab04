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


// 10. Lock the whole route (controller) except for authorized
namespace myAppMemory.Controllers {

  [Authorize] // 10
  public class CancellationsController : Controller {

    private DataContext dc;
    private UserManager<ApplicationUser> manager;


    // Methods alphabetically

    // A

    //===================================================
    // All() - GET: /Cancellations/All
    // 10. this route is locked for all but Admin
    //   i.e. Igor/123456
    //===================================================
    [Authorize(Roles = "Admin")] // 10
    public async Task<ActionResult> All() {
      return View(await dc.Cancellations.ToListAsync());
    }

    // C

    //===================================================
    // CancellationsController() - contstructor
    //===================================================
    public CancellationsController() {
      dc = new DataContext();
      manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dc));
    }

    //===================================================
    // Create() - GET: /Cancellations/Create
    //===================================================
    public ActionResult Create() {
      return View();
    }

    //===================================================
    // Create() - POST: /Cancellations/Create
    // 20. Include = "Id, Message", but not "User"
    //===================================================
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create([Bind(Include = "Id,Message")] Cancellation cancellation) { // 20
      var currentUser = await manager.FindByIdAsync(User.Identity.GetUserId());
      if (ModelState.IsValid) {
        cancellation.User = currentUser;
        dc.Cancellations.Add(cancellation);
        await dc.SaveChangesAsync();
        return RedirectToAction("Index");
      }

      return View(cancellation);
    }



    // D

    //===================================================
    // Delete() - GET: /Cancellations/Delete/5
    //===================================================
    public async Task<ActionResult> Delete(int? id) {
      var currentUser = await manager.FindByIdAsync(User.Identity.GetUserId());
      if (id == null) {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Cancellation cancellation = await dc.Cancellations.FindAsync(id);
      if (cancellation == null) {
        return HttpNotFound();
      }
      if (cancellation.User.Id != currentUser.Id) {
        return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
      }
      return View(cancellation);
    }

    //===================================================
    // Delete() - POST: /Cancellations/Delete/5
    //===================================================
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(int id) {
      Cancellation cancellation = await dc.Cancellations.FindAsync(id);
      dc.Cancellations.Remove(cancellation);
      await dc.SaveChangesAsync();
      return RedirectToAction("Index");
    }

    //===================================================
    // Details() - GET: /Cancellations/Details/5
    //===================================================
    public async Task<ActionResult> Details(int? id) {
      var currentUser = await manager.FindByIdAsync(User.Identity.GetUserId());
      if (id == null) {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Cancellation cancellation = await dc.Cancellations.FindAsync(id);
      if (cancellation == null) {
        return HttpNotFound();
      }
      if (cancellation.User.Id != currentUser.Id) {
        return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
      }
      return View(cancellation);
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
    // Edit() - GET: /Cancellations/Edit/5
    //===================================================
    public async Task<ActionResult> Edit(int? id) {
      var currentUser = await manager.FindByIdAsync(User.Identity.GetUserId());
      if (id == null) {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Cancellation cancellation = await dc.Cancellations.FindAsync(id);
      if (cancellation == null) {
        return HttpNotFound();
      }
      if (cancellation.User.Id != currentUser.Id) {
        return new HttpStatusCodeResult(HttpStatusCode.Unauthorized);
      }
      return View(cancellation);
    }

    //===================================================
    // Edit() - POST: /Cancellations/Edit/5
    //===================================================
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit([Bind(Include = "Id,Message")] Cancellation cancellation) {
      if (ModelState.IsValid) {
        dc.Entry(cancellation).State = EntityState.Modified;
        await dc.SaveChangesAsync();
        return RedirectToAction("Index");
      }
      return View(cancellation);
    }


    // I

    //===================================================
    // Index() - GET: /Cancellations/
    //===================================================
    public ActionResult Index() {
      var currentUser = manager.FindById(User.Identity.GetUserId());
      return View(dc.Cancellations.ToList().Where(cancellation => cancellation.User.Id == currentUser.Id));
    }



  }
}
