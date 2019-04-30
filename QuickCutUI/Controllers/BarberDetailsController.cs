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
    public class BarberDetailsController : Controller
    {
        private QuickCutDataEntities db = new QuickCutDataEntities();

        // GET: BarberDetails
        public ActionResult Index()
        {
            var barberDetails = db.BarberDetails.Include(b => b.Barber);
            return View(barberDetails.ToList());
        }

        // GET: BarberDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BarberDetail barberDetail = db.BarberDetails.Find(id);
            if (barberDetail == null)
            {
                return HttpNotFound();
            }
            return View(barberDetail);
        }

        // GET: BarberDetails/Create
        public ActionResult Create()
        {
            ViewBag.BarberID = new SelectList(db.Barbers, "BarberID", "FirstName");
            return View();
        }

        // POST: BarberDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BarberID,PhoneNumber,OperationHours,DaysOfWeek,PolicyInfo")] BarberDetail barberDetail)
        {
            if (ModelState.IsValid)
            {
                db.BarberDetails.Add(barberDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BarberID = new SelectList(db.Barbers, "BarberID", "FirstName", barberDetail.BarberID);
            return View(barberDetail);
        }

        // GET: BarberDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BarberDetail barberDetail = db.BarberDetails.Find(id);
            if (barberDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.BarberID = new SelectList(db.Barbers, "BarberID", "FirstName", barberDetail.BarberID);
            return View(barberDetail);
        }

        // POST: BarberDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BarberID,PhoneNumber,OperationHours,DaysOfWeek,PolicyInfo")] BarberDetail barberDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(barberDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BarberID = new SelectList(db.Barbers, "BarberID", "FirstName", barberDetail.BarberID);
            return View(barberDetail);
        }

        // GET: BarberDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BarberDetail barberDetail = db.BarberDetails.Find(id);
            if (barberDetail == null)
            {
                return HttpNotFound();
            }
            return View(barberDetail);
        }

        // POST: BarberDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BarberDetail barberDetail = db.BarberDetails.Find(id);
            db.BarberDetails.Remove(barberDetail);
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
