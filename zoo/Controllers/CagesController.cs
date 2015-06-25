using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using zoo.Models;

namespace zoo.Controllers
{
    public class CagesController : Controller
    {
        private KUASCsharpEntities db = new KUASCsharpEntities();

        // GET: Cages
        public ActionResult Index()
        {
            return View(db.Cage.ToList());
        }

        // GET: Cages/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cage cage = db.Cage.Find(id);
            if (cage == null)
            {
                return HttpNotFound();
            }
            return View(cage);
        }

        // GET: Cages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cages/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CageID,area")] Cage cage)
        {
            if (ModelState.IsValid)
            {
                db.Cage.Add(cage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cage);
        }

        // GET: Cages/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cage cage = db.Cage.Find(id);
            if (cage == null)
            {
                return HttpNotFound();
            }
            return View(cage);
        }

        // POST: Cages/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CageID,area")] Cage cage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cage);
        }

        // GET: Cages/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cage cage = db.Cage.Find(id);
            if (cage == null)
            {
                return HttpNotFound();
            }
            return View(cage);
        }

        // POST: Cages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Cage cage = db.Cage.Find(id);
            db.Cage.Remove(cage);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
