using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanlyThuVienCuaHung.Models;

namespace QuanlyThuVienCuaHung.Controllers
{
    [Authorize(Users = "admin@gmail.com")]
    public class LOAI_DOCGIAController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: LOAI_DOCGIA
        public ActionResult Index()
        {
            return View(db.LOAI_DOCGIA.ToList());
        }

        // GET: LOAI_DOCGIA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAI_DOCGIA lOAI_DOCGIA = db.LOAI_DOCGIA.Find(id);
            if (lOAI_DOCGIA == null)
            {
                return HttpNotFound();
            }
            return View(lOAI_DOCGIA);
        }

        // GET: LOAI_DOCGIA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LOAI_DOCGIA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoaiDG,TenLoaiDG")] LOAI_DOCGIA lOAI_DOCGIA)
        {
            if (ModelState.IsValid)
            {
                db.LOAI_DOCGIA.Add(lOAI_DOCGIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOAI_DOCGIA);
        }

        // GET: LOAI_DOCGIA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAI_DOCGIA lOAI_DOCGIA = db.LOAI_DOCGIA.Find(id);
            if (lOAI_DOCGIA == null)
            {
                return HttpNotFound();
            }
            return View(lOAI_DOCGIA);
        }

        // POST: LOAI_DOCGIA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoaiDG,TenLoaiDG")] LOAI_DOCGIA lOAI_DOCGIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOAI_DOCGIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOAI_DOCGIA);
        }

        // GET: LOAI_DOCGIA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAI_DOCGIA lOAI_DOCGIA = db.LOAI_DOCGIA.Find(id);
            if (lOAI_DOCGIA == null)
            {
                return HttpNotFound();
            }
            return View(lOAI_DOCGIA);
        }

        // POST: LOAI_DOCGIA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOAI_DOCGIA lOAI_DOCGIA = db.LOAI_DOCGIA.Find(id);
            db.LOAI_DOCGIA.Remove(lOAI_DOCGIA);
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
