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
    public class PHIEU_THU_PHATController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: PHIEU_THU_PHAT
        public ActionResult Index()
        {
            var pHIEU_THU_PHAT = db.PHIEU_THU_PHAT.Include(p => p.AspNetUser);
            return View(pHIEU_THU_PHAT.ToList());
        }

        // GET: PHIEU_THU_PHAT/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEU_THU_PHAT pHIEU_THU_PHAT = db.PHIEU_THU_PHAT.Find(id);
            if (pHIEU_THU_PHAT == null)
            {
                return HttpNotFound();
            }
            return View(pHIEU_THU_PHAT);
        }

        // GET: PHIEU_THU_PHAT/Create
        public ActionResult Create()
        {
            ViewBag.MaDG = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: PHIEU_THU_PHAT/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieuThuPhat,MaDG,SoTienThu")] PHIEU_THU_PHAT pHIEU_THU_PHAT)
        {
            if (ModelState.IsValid)
            {
                db.PHIEU_THU_PHAT.Add(pHIEU_THU_PHAT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDG = new SelectList(db.AspNetUsers, "Id", "Email", pHIEU_THU_PHAT.MaDG);
            return View(pHIEU_THU_PHAT);
        }

        // GET: PHIEU_THU_PHAT/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEU_THU_PHAT pHIEU_THU_PHAT = db.PHIEU_THU_PHAT.Find(id);
            if (pHIEU_THU_PHAT == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDG = new SelectList(db.AspNetUsers, "Id", "Email", pHIEU_THU_PHAT.MaDG);
            return View(pHIEU_THU_PHAT);
        }

        // POST: PHIEU_THU_PHAT/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhieuThuPhat,MaDG,SoTienThu")] PHIEU_THU_PHAT pHIEU_THU_PHAT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHIEU_THU_PHAT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDG = new SelectList(db.AspNetUsers, "Id", "Email", pHIEU_THU_PHAT.MaDG);
            return View(pHIEU_THU_PHAT);
        }

        // GET: PHIEU_THU_PHAT/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEU_THU_PHAT pHIEU_THU_PHAT = db.PHIEU_THU_PHAT.Find(id);
            if (pHIEU_THU_PHAT == null)
            {
                return HttpNotFound();
            }
            return View(pHIEU_THU_PHAT);
        }

        // POST: PHIEU_THU_PHAT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PHIEU_THU_PHAT pHIEU_THU_PHAT = db.PHIEU_THU_PHAT.Find(id);
            db.PHIEU_THU_PHAT.Remove(pHIEU_THU_PHAT);
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
