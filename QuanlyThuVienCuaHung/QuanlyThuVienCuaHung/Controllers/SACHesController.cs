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
    public class SACHesController : Controller
    {

        private Entities1 db = new Entities1();

        // GET: SACHes
        public ActionResult Index()
        {
            var sACHes = db.SACHes.Include(s => s.LOAI_SACH).Include(s => s.TAC_GIA);
            return View(sACHes.ToList());
        }

        // GET: SACHes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACHes.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            return View(sACH);
        }

        // GET: SACHes/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiSach = new SelectList(db.LOAI_SACH, "MaLoaiSach", "TenLoaiSach");
            ViewBag.MaTG = new SelectList(db.TAC_GIA, "MaTG", "TenTG");
            return View();
        }

        // POST: SACHes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSach,MaTG,MaLoaiSach,TenSach,NamXuatBan,NhaXuatBan,HanTra,TinhTrang")] SACH sACH)
        {
            if (ModelState.IsValid)
            {
                db.SACHes.Add(sACH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiSach = new SelectList(db.LOAI_SACH, "MaLoaiSach", "TenLoaiSach", sACH.MaLoaiSach);
            ViewBag.MaTG = new SelectList(db.TAC_GIA, "MaTG", "TenTG", sACH.MaTG);
            return View(sACH);
        }

        // GET: SACHes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACHes.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiSach = new SelectList(db.LOAI_SACH, "MaLoaiSach", "TenLoaiSach", sACH.MaLoaiSach);
            ViewBag.MaTG = new SelectList(db.TAC_GIA, "MaTG", "TenTG", sACH.MaTG);
            return View(sACH);
        }

        // POST: SACHes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSach,MaTG,MaLoaiSach,TenSach,NamXuatBan,NhaXuatBan,HanTra,TinhTrang")] SACH sACH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiSach = new SelectList(db.LOAI_SACH, "MaLoaiSach", "TenLoaiSach", sACH.MaLoaiSach);
            ViewBag.MaTG = new SelectList(db.TAC_GIA, "MaTG", "TenTG", sACH.MaTG);
            return View(sACH);
        }

        // GET: SACHes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACHes.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            return View(sACH);
        }

        // POST: SACHes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SACH sACH = db.SACHes.Find(id);
            db.SACHes.Remove(sACH);
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
