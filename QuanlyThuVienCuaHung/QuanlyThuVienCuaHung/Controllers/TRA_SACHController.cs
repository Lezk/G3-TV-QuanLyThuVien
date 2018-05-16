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
    [Authorize(Users ="admin@gmail.com")]
    public class TRA_SACHController : Controller
    {
        
        private Entities1 db = new Entities1();

        // GET: TRA_SACH
        public ActionResult Index()
        {
            var dOC_Gia = db.TRA_SACH.Include(x=>x.PHIEU_MUON_SACH.AspNetUser);
            var tRA_SACH = db.TRA_SACH.Include(t => t.PHIEU_MUON_SACH.SACH);
            return View(tRA_SACH.ToList());
            return View(dOC_Gia.ToList());
        }

        // GET: TRA_SACH/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRA_SACH tRA_SACH = db.TRA_SACH.Find(id);
            if (tRA_SACH == null)
            {
                return HttpNotFound();
            }
            return View(tRA_SACH);
        }

        // GET: TRA_SACH/Create
        public ActionResult Create()
        {
            ViewBag.MaPhieuMuon = new SelectList(db.PHIEU_MUON_SACH, "MaPhieuMuon", "MaDG");
            return View();
        }

        // POST: TRA_SACH/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieuTra,MaPhieuMuon,NgayTra,TienPhat")] TRA_SACH tRA_SACH)
        {
            if (ModelState.IsValid)
            {
                db.TRA_SACH.Add(tRA_SACH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPhieuMuon = new SelectList(db.PHIEU_MUON_SACH, "MaPhieuMuon", "MaDG", tRA_SACH.MaPhieuMuon);
            return View(tRA_SACH);
        }

        // GET: TRA_SACH/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRA_SACH tRA_SACH = db.TRA_SACH.Find(id);
            if (tRA_SACH == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPhieuMuon = new SelectList(db.PHIEU_MUON_SACH, "MaPhieuMuon", "MaDG", tRA_SACH.MaPhieuMuon);
            return View(tRA_SACH);
        }

        // POST: TRA_SACH/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhieuTra,MaPhieuMuon,NgayTra,TienPhat")] TRA_SACH tRA_SACH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tRA_SACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPhieuMuon = new SelectList(db.PHIEU_MUON_SACH, "MaPhieuMuon", "MaDG", tRA_SACH.MaPhieuMuon);
            return View(tRA_SACH);
        }

        // GET: TRA_SACH/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRA_SACH tRA_SACH = db.TRA_SACH.Find(id);
            if (tRA_SACH == null)
            {
                return HttpNotFound();
            }
            return View(tRA_SACH);
        }

        // POST: TRA_SACH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TRA_SACH tRA_SACH = db.TRA_SACH.Find(id);
            db.TRA_SACH.Remove(tRA_SACH);
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
