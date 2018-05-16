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
    public class BoSungThongTinKhiDangKyController : Controller
    {
        private Entities1 db = new Entities1();
        // GET: BoSungThongTinKhiDangKy
        public ActionResult Index()
        {
            return View();
        }
        // GET: AspNetUsers/Edit/5
        public ActionResult Fill(string id)
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
        public ActionResult Fill([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,MaLoaiDG,HoTen,NgaySinh,DiaChi,NgayLapThe,TienNo,HanThe")] AspNetUser aspNetUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aspNetUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.MaLoaiDG = new SelectList(db.LOAI_DOCGIA, "MaLoaiDG", "TenLoaiDG", aspNetUser.MaLoaiDG);
            return View(aspNetUser);
        }
    }
}