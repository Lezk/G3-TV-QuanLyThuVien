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
    public class LOAI_SACHController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: LOAI_SACH
        public ActionResult Index()
        {
            return View(db.LOAI_SACH.ToList());
        }

        // GET: LOAI_SACH/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAI_SACH lOAI_SACH = db.LOAI_SACH.Find(id);
            if (lOAI_SACH == null)
            {
                return HttpNotFound();
            }
            return View(lOAI_SACH);
        }

        // GET: LOAI_SACH/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LOAI_SACH/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoaiSach,TenLoaiSach")] LOAI_SACH lOAI_SACH)
        {
            if (ModelState.IsValid)
            {
                db.LOAI_SACH.Add(lOAI_SACH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lOAI_SACH);
        }

        // GET: LOAI_SACH/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAI_SACH lOAI_SACH = db.LOAI_SACH.Find(id);
            if (lOAI_SACH == null)
            {
                return HttpNotFound();
            }
            return View(lOAI_SACH);
        }

        // POST: LOAI_SACH/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoaiSach,TenLoaiSach")] LOAI_SACH lOAI_SACH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOAI_SACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lOAI_SACH);
        }

        // GET: LOAI_SACH/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOAI_SACH lOAI_SACH = db.LOAI_SACH.Find(id);
            if (lOAI_SACH == null)
            {
                return HttpNotFound();
            }
            return View(lOAI_SACH);
        }

        // POST: LOAI_SACH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOAI_SACH lOAI_SACH = db.LOAI_SACH.Find(id);
            db.LOAI_SACH.Remove(lOAI_SACH);
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
