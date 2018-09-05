using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetStore.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Validation;

namespace PetStore.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            var id = User.Identity.GetUserId();
            var customer = db.Customers.Include(c => c.ShippingAddress).Include(c => c.PaymentInformation).Include(c => c.BillingAddress).Where(c => c.UserId.Equals(id)) as Customer;
            
            return View(customer);

            //ViewBag.Months = new SelectList(db.PaymentInformation, "Months", "Months".ToString());
            //ViewBag.Years = new SelectList(db.PaymentInformation, "Years", "Years".ToString());
            //return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "Id,FirstName,LastName,PhoneNumber,EmailAddress,BillingAddressIsDifferent,ShippingAddressId,PaymentInformationId,BillingAddressId,ShippingAddress,BillingAddress,PaymentInformation")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var billing = customer.BillingAddress;
                var shipping = customer.ShippingAddress;
                var payment = customer.PaymentInformation;
                                                       
                db.BillingAddresses.Add(billing);
                db.ShippingAddresses.Add(shipping);
                db.PaymentInformation.Add(payment);
                db.Customers.Add(customer);

                db.SaveChanges();
                return RedirectToAction("Details");
            }

            // how to return other objects to the view?? (shipping, payment, and billing) when the page is reloaded?
            // ie, when the submit button is clicked but the model state is not valid... ?
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,OrderId,CustomerPhone,CustomerEmail,ShippingFirstName,ShippingLastName,ShippingAddress1,ShippingAddress2,ShippingCity,ShippingState,ShippingPostalCode,CardNumber,ExpirationMonth,ExpirationYear,CardPin,BillingFirstName,BillingLastName,BillingAddress1,BillingAddress2,BillingCity,BillingState,BillingPostalCode")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
