using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuickCutUI.Models;

namespace QuickCutUI.Controllers
{
    public class BarbersController : Controller
    {
        private QuickCutDataEntities db = new QuickCutDataEntities();

        // GET: Barbers
        public ActionResult Index()
        {
            var barbers = db.Barbers.Include(b => b.BarberDetail).Include(b => b.Service);
            return View(barbers.ToList());
        }

        // GET: Barbers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barber barber = db.Barbers.Find(id);
            if (barber == null)
            {
                return HttpNotFound();
            }
            return View(barber);
        }

        // GET: Barbers/Create
        public ActionResult Create()
        {
            ViewBag.BarberID = new SelectList(db.BarberDetails, "BarberID", "PhoneNumber");
            ViewBag.BarberID = new SelectList(db.Services, "BarberID", "ServiceTitle");
            return View();
        }

        // POST: Barbers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BarberID,FirstName,LastName,BarberAddress,Zip")] Barber barber)
        {
            if (ModelState.IsValid)
            {
                db.Barbers.Add(barber);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BarberID = new SelectList(db.BarberDetails, "BarberID", "PhoneNumber", barber.BarberID);
            ViewBag.BarberID = new SelectList(db.Services, "BarberID", "ServiceTitle", barber.BarberID);
            return View(barber);
        }

        // GET: Barbers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barber barber = db.Barbers.Find(id);
            if (barber == null)
            {
                return HttpNotFound();
            }
            ViewBag.BarberID = new SelectList(db.BarberDetails, "BarberID", "PhoneNumber", barber.BarberID);
            ViewBag.BarberID = new SelectList(db.Services, "BarberID", "ServiceTitle", barber.BarberID);
            return View(barber);
        }

        // POST: Barbers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BarberID,FirstName,LastName,BarberAddress,Zip")] Barber barber)
        {
            if (ModelState.IsValid)
            {
                db.Entry(barber).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BarberID = new SelectList(db.BarberDetails, "BarberID", "PhoneNumber", barber.BarberID);
            ViewBag.BarberID = new SelectList(db.Services, "BarberID", "ServiceTitle", barber.BarberID);
            return View(barber);
        }

        // GET: Barbers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barber barber = db.Barbers.Find(id);
            if (barber == null)
            {
                return HttpNotFound();
            }
            return View(barber);
        }

        // POST: Barbers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Barber barber = db.Barbers.Find(id);
            db.Barbers.Remove(barber);
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
