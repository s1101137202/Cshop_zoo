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
    public class AnimalsController : Controller
    {
        private KUASCsharpEntities db = new KUASCsharpEntities();

        // GET: Animals
        public ActionResult Index()
        {
            var animal = db.Animal.Include(a => a.Cage).Include(a => a.Kind);
            return View(animal.ToList());
        }

        // GET: Animals/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animal.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: Animals/Create
        public ActionResult Create()
        {
            ViewBag.CageID = new SelectList(db.Cage, "CageID", "area");
            ViewBag.KindID = new SelectList(db.Kind, "KindID", "KindName");
            return View();
        }

        // POST: Animals/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnimalID,AnimalName,Animalbirth,KindID,CageID")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Animal.Add(animal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CageID = new SelectList(db.Cage, "CageID", "area", animal.CageID);
            ViewBag.KindID = new SelectList(db.Kind, "KindID", "KindName", animal.KindID);
            return View(animal);
        }

        // GET: Animals/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animal.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            ViewBag.CageID = new SelectList(db.Cage, "CageID", "area", animal.CageID);
            ViewBag.KindID = new SelectList(db.Kind, "KindID", "KindName", animal.KindID);
            return View(animal);
        }

        // POST: Animals/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnimalID,AnimalName,Animalbirth,KindID,CageID")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CageID = new SelectList(db.Cage, "CageID", "area", animal.CageID);
            ViewBag.KindID = new SelectList(db.Kind, "KindID", "KindName", animal.KindID);
            return View(animal);
        }

        // GET: Animals/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animal.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Animal animal = db.Animal.Find(id);
            db.Animal.Remove(animal);
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
