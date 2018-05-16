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
    public class HomeController : Controller
    {
        private Entities1 db = new Entities1();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            return View(aspNetUser);
        }
        public ActionResult xemsach()
        {
            return View();
        }
        public ActionResult muonsach()
        {
            ViewBag.MaDG = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.MaSach = new SelectList(db.SACHes.Where(d=>d.TinhTrang.Equals("Chưa Mượn")), "MaSach", "TenSach");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult muonsach([Bind(Include = "MaPhieuMuon,MaDG,MaSach,NgayMuon")] PHIEU_MUON_SACH pHIEU_MUON_SACH)
        {
            if (ModelState.IsValid)
            {
                int masach = int.Parse(pHIEU_MUON_SACH.MaSach.ToString());
                SACH sACH = new SACH();
                sACH = db.SACHes.Single(d => d.MaSach.Equals(masach));
               
                sACH.TinhTrang = "Đã Mượn";
                db.Entry(sACH).State = EntityState.Modified;
                db.SaveChanges();

                db.PHIEU_MUON_SACH.Add(pHIEU_MUON_SACH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDG = new SelectList(db.AspNetUsers, "Id", "Email", pHIEU_MUON_SACH.MaDG);
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TenSach", pHIEU_MUON_SACH.MaSach);
            return View(pHIEU_MUON_SACH);
        }
        public ActionResult xemsachminhmuon()
        {
            
            return View();
        }
        public ActionResult trasachdamuon(int? masach)
        {
            if (masach == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewData["masach"] = masach;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult trasachdamuon([Bind(Include = "MaPhieuTra,MaPhieuMuon,NgayTra,TienPhat")] TRA_SACH tRA_SACH)
        {
            if (ModelState.IsValid)
            {
                var listphieumuonsach = db.PHIEU_MUON_SACH.ToList();
                int masachtra = int.Parse(listphieumuonsach.Single(z => z.MaPhieuMuon.Equals(tRA_SACH.MaPhieuMuon)).MaSach.ToString());
                SACH sACH = new SACH();
                sACH = db.SACHes.Single(d => d.MaSach.Equals(masachtra));

                sACH.TinhTrang = "Chưa Mượn";
                db.Entry(sACH).State = EntityState.Modified;
                db.SaveChanges();
                db.TRA_SACH.Add(tRA_SACH);
                db.SaveChanges();
                return RedirectToAction("xemsachminhmuon");
            }

            ViewBag.MaPhieuMuon = new SelectList(db.PHIEU_MUON_SACH, "MaPhieuMuon", "MaDG", tRA_SACH.MaPhieuMuon);
            return View(tRA_SACH);
        }

        // GET: AspNetUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser aspNetUser = db.AspNetUsers.Find(id);
            if (aspNetUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiDG = new SelectList(db.LOAI_DOCGIA, "MaLoaiDG", "TenLoaiDG", aspNetUser.MaLoaiDG);
            return View(aspNetUser);
        }

        // POST: AspNetUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,MaLoaiDG,HoTen,NgaySinh,DiaChi,NgayLapThe,TienNo,HanThe")] AspNetUser aspNetUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aspNetUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiDG = new SelectList(db.LOAI_DOCGIA, "MaLoaiDG", "TenLoaiDG", aspNetUser.MaLoaiDG);
            return View(aspNetUser);
        }
    }
}