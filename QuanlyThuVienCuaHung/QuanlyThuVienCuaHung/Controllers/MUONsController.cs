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
    public class MUONsController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: MUONs
        public ActionResult Index()
        {
            var mUONs = db.MUONs.Include(m => m.AspNetUser).Include(m => m.SACH);
            return View(mUONs.ToList());
        }

        // GET: MUONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MUON mUON = db.MUONs.Find(id);
            if (mUON == null)
            {
                return HttpNotFound();
            }
            return View(mUON);
        }

        // GET: MUONs/Create
        public ActionResult Create()
        {
            ViewBag.MaDG = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TenSach");
            return View();
        }

        // POST: MUONs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieuMuon,MaSach,MaDG")] MUON mUON)
        {
            if (ModelState.IsValid)
            {
                db.MUONs.Add(mUON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDG = new SelectList(db.AspNetUsers, "Id", "Email", mUON.MaDG);
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TenSach", mUON.MaSach);
            return View(mUON);
        }

        // GET: MUONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MUON mUON = db.MUONs.Find(id);
            if (mUON == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDG = new SelectList(db.AspNetUsers, "Id", "Email", mUON.MaDG);
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TenSach", mUON.MaSach);
            return View(mUON);
        }

        // POST: MUONs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhieuMuon,MaSach,MaDG")] MUON mUON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mUON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDG = new SelectList(db.AspNetUsers, "Id", "Email", mUON.MaDG);
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TenSach", mUON.MaSach);
            return View(mUON);
        }

        // GET: MUONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MUON mUON = db.MUONs.Find(id);
            if (mUON == null)
            {
                return HttpNotFound();
            }
            return View(mUON);
        }

        // POST: MUONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MUON mUON = db.MUONs.Find(id);
            db.MUONs.Remove(mUON);
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
