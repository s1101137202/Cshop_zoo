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
    public class KindsController : Controller
    {
        private KUASCsharpEntities db = new KUASCsharpEntities();

        // GET: Kinds
        public ActionResult Index()
        {
            return View(db.Kind.ToList());
        }

        // GET: Kinds/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kind kind = db.Kind.Find(id);
            if (kind == null)
            {
                return HttpNotFound();
            }
            return View(kind);
        }

        // GET: Kinds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kinds/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KindID,KindName")] Kind kind)
        {
            if (ModelState.IsValid)
            {
                db.Kind.Add(kind);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kind);
        }

        // GET: Kinds/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kind kind = db.Kind.Find(id);
            if (kind == null)
            {
                return HttpNotFound();
            }
            return View(kind);
        }

        // POST: Kinds/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KindID,KindName")] Kind kind)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kind).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kind);
        }

        // GET: Kinds/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kind kind = db.Kind.Find(id);
            if (kind == null)
            {
                return HttpNotFound();
            }
            return View(kind);
        }

        // POST: Kinds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Kind kind = db.Kind.Find(id);
            db.Kind.Remove(kind);
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
