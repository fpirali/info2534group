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
            var customers = db.Customers.Include(c => c.ShippingAddress).Include(c => c.BillingAddress).Include(c => c.PaymentInformation);
            return View(customers.ToList());
        }

        // GET: Customers address info
        public ActionResult IndexAddress()
        {
            var customers = db.Customers.Include(c => c.BillingAddress).Include(c => c.ShippingAddress);
            return View(customers.ToList());
        }

        // GET: Customers payment info
        public ActionResult IndexPayment()
        {
            var customers = db.Customers.Include(c => c.PaymentInformation);
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var customers = db.Customers.Include(c => c.ShippingAddress).Include(c => c.BillingAddress).Include(c => c.PaymentInformation);
            Customer customer = customers.Where(c => c.Id == id).FirstOrDefault();

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/CreatePayment
        public ActionResult CreatePayment(
            [Bind(Include = "PaymentInformationId,PaymentInformation")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var payment = customer.PaymentInformation;
                db.PaymentInformation.Add(payment);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/CreateBilling
        public ActionResult CreateBilling(
            [Bind(Include = "BillingAddressId,BillingAddress")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var billing = customer.BillingAddress;
                db.BillingAddresses.Add(billing);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET:Customers/CreateShipping
        public ActionResult CreateShipping(
            [Bind(Include = "ShippingAddressId,ShippingAddress")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var shipping = customer.ShippingAddress;
                db.ShippingAddresses.Add(shipping);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();

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
                return RedirectToAction("Index");
            }
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
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,PhoneNumber,EmailAddress,BillingAddressIsDifferent,ShippingAddressId,PaymentInformationId,BillingAddressId,ShippingAddress,BillingAddress,PaymentInformation")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                var billing = customer.BillingAddress;
                var shipping = customer.ShippingAddress;
                var payment = customer.PaymentInformation;

                db.Entry(billing).State = EntityState.Modified;
                db.Entry(shipping).State = EntityState.Modified;
                db.Entry(payment).State = EntityState.Modified;
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
            BillingAddress billing = db.BillingAddresses.Find(customer.BillingAddressId);
            ShippingAddress shipping = db.ShippingAddresses.Find(customer.ShippingAddressId);
            PaymentInformation payment = db.PaymentInformation.Find(customer.PaymentInformationId);

            db.BillingAddresses.Remove(billing);
            db.ShippingAddresses.Remove(shipping);
            db.PaymentInformation.Remove(payment);
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
