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
    public class TAC_GIAController : Controller
    {
        private Entities1 db = new Entities1();

        // GET: TAC_GIA
        public ActionResult Index()
        {
            return View(db.TAC_GIA.ToList());
        }

        // GET: TAC_GIA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAC_GIA tAC_GIA = db.TAC_GIA.Find(id);
            if (tAC_GIA == null)
            {
                return HttpNotFound();
            }
            return View(tAC_GIA);
        }

        // GET: TAC_GIA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TAC_GIA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTG,TenTG")] TAC_GIA tAC_GIA)
        {
            if (ModelState.IsValid)
            {
                db.TAC_GIA.Add(tAC_GIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tAC_GIA);
        }

        // GET: TAC_GIA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAC_GIA tAC_GIA = db.TAC_GIA.Find(id);
            if (tAC_GIA == null)
            {
                return HttpNotFound();
            }
            return View(tAC_GIA);
        }

        // POST: TAC_GIA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTG,TenTG")] TAC_GIA tAC_GIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tAC_GIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tAC_GIA);
        }

        // GET: TAC_GIA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TAC_GIA tAC_GIA = db.TAC_GIA.Find(id);
            if (tAC_GIA == null)
            {
                return HttpNotFound();
            }
            return View(tAC_GIA);
        }

        // POST: TAC_GIA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TAC_GIA tAC_GIA = db.TAC_GIA.Find(id);
            db.TAC_GIA.Remove(tAC_GIA);
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
