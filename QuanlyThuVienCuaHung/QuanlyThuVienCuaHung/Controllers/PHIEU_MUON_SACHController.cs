using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using QuanlyThuVienCuaHung.Models;

namespace QuanlyThuVienCuaHung.Controllers
{
    [Authorize(Users = "admin@gmail.com")]
    public class PHIEU_MUON_SACHController : Controller
    {

        private Entities1 db = new Entities1();

        // GET: PHIEU_MUON_SACH
        public ActionResult Index()
        {
            var pHIEU_MUON_SACH = db.PHIEU_MUON_SACH.Include(p => p.AspNetUser).Include(p => p.SACH);
            return View(pHIEU_MUON_SACH.ToList());
        }

        // GET: PHIEU_MUON_SACH/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEU_MUON_SACH pHIEU_MUON_SACH = db.PHIEU_MUON_SACH.Find(id);
            if (pHIEU_MUON_SACH == null)
            {
                return HttpNotFound();
            }
            return View(pHIEU_MUON_SACH);
        }

        // GET: PHIEU_MUON_SACH/Create
        public ActionResult Create()
        {
            ViewBag.MaDG = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TenSach");
            return View();
        }

        // POST: PHIEU_MUON_SACH/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhieuMuon,MaDG,MaSach,NgayMuon")] PHIEU_MUON_SACH pHIEU_MUON_SACH)
        {
            if (ModelState.IsValid)
            {
                db.PHIEU_MUON_SACH.Add(pHIEU_MUON_SACH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDG = new SelectList(db.AspNetUsers, "Id", "Email", pHIEU_MUON_SACH.MaDG);
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TenSach", pHIEU_MUON_SACH.MaSach);
            return View(pHIEU_MUON_SACH);
        }

        // GET: PHIEU_MUON_SACH/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEU_MUON_SACH pHIEU_MUON_SACH = db.PHIEU_MUON_SACH.Find(id);
            if (pHIEU_MUON_SACH == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDG = new SelectList(db.AspNetUsers, "Id", "Email", pHIEU_MUON_SACH.MaDG);
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TenSach", pHIEU_MUON_SACH.MaSach);
            return View(pHIEU_MUON_SACH);
        }

        // POST: PHIEU_MUON_SACH/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhieuMuon,MaDG,MaSach,NgayMuon")] PHIEU_MUON_SACH pHIEU_MUON_SACH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pHIEU_MUON_SACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDG = new SelectList(db.AspNetUsers, "Id", "Email", pHIEU_MUON_SACH.MaDG);
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TenSach", pHIEU_MUON_SACH.MaSach);
            return View(pHIEU_MUON_SACH);
        }

        // GET: PHIEU_MUON_SACH/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PHIEU_MUON_SACH pHIEU_MUON_SACH = db.PHIEU_MUON_SACH.Find(id);
            if (pHIEU_MUON_SACH == null)
            {
                return HttpNotFound();
            }
            return View(pHIEU_MUON_SACH);
        }

        // POST: PHIEU_MUON_SACH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PHIEU_MUON_SACH pHIEU_MUON_SACH = db.PHIEU_MUON_SACH.Find(id);
            db.PHIEU_MUON_SACH.Remove(pHIEU_MUON_SACH);
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
        public ActionResult BaoCaoMuonSach()
        {
            List<PHIEU_MUON_SACH> PhieuMuonSach = db.PHIEU_MUON_SACH.ToList();
            foreach(var item in PhieuMuonSach)
            {
                item.MaDG = db.AspNetUsers.Single(t => t.Id.Equals(item.MaDG.ToString())).HoTen;
                
            }
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "BaoCaoMuonSach.rpt"));
            rd.SetDataSource(PhieuMuonSach);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "BaoCaoMuonSach.pdf");
            }
            catch
            {
                throw;
            }

        }
    }
}
