using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetStore.Models;

namespace PetStore.Controllers
{
    public class PaymentInformationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PaymentInformations
        public ActionResult Index()
        {
            return View(db.PaymentInformation.ToList());
        }

        // GET: PaymentInformations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentInformation paymentInformation = db.PaymentInformation.Find(id);
            if (paymentInformation == null)
            {
                return HttpNotFound();
            }
            return View(paymentInformation);
        }

        // GET: PaymentInformations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentInformations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CardNumber,ExpirationMonth,ExpirationYear,CardPin")] PaymentInformation paymentInformation)
        {
            if (ModelState.IsValid)
            {
                db.PaymentInformation.Add(paymentInformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(paymentInformation);
        }

        // GET: PaymentInformations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentInformation paymentInformation = db.PaymentInformation.Find(id);
            if (paymentInformation == null)
            {
                return HttpNotFound();
            }
            return View(paymentInformation);
        }

        // POST: PaymentInformations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CardNumber,ExpirationMonth,ExpirationYear,CardPin")] PaymentInformation paymentInformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paymentInformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paymentInformation);
        }

        // GET: PaymentInformations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentInformation paymentInformation = db.PaymentInformation.Find(id);
            if (paymentInformation == null)
            {
                return HttpNotFound();
            }
            return View(paymentInformation);
        }

        // POST: PaymentInformations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PaymentInformation paymentInformation = db.PaymentInformation.Find(id);
            db.PaymentInformation.Remove(paymentInformation);
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
