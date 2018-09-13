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

        /**************************************
         * these are all of the get events *
        **************************************/
        // GET: Customers
        [Authorize(Roles = "Admin,Customer")]
        public ActionResult Index(int? id)
        {
            var customers = db.Customers.Include(c => c.ShippingAddress).Include(c => c.BillingAddress).Include(c => c.PaymentInformation);

            if (User.IsInRole("Admin"))
            {
                return View(customers.ToList());
            }
            else
            {
                customers = customers.Where(c => c.Id == id);
                return View(customers.ToList());
            }
        }

        // GET: Customers address info
        [Authorize(Roles = "Admin,Customer")]
        public ActionResult IndexAddress(int? id)
        {
            var customers = db.Customers.Include(c => c.BillingAddress).Include(c => c.ShippingAddress);

            if (User.IsInRole("Admin"))
            {
                return View(customers.ToList());
            }
            else
            {
                customers = customers.Where(c => c.Id == id);
                return View(customers.ToList());
            }
        }

        // GET: Customers payment info
        [Authorize(Roles = "Admin,Customer")]
        public ActionResult IndexPayment(int? id)
        {
            var customers = db.Customers.Include(c => c.PaymentInformation);

            if (User.IsInRole("Admin"))
            {
                return View(customers.ToList());
            }
            else
            {
                customers = customers.Where(c => c.Id == id);
                return View(customers.ToList());
            }
        }

        // GET: Customers/CreatePayment
        [AllowAnonymous]
        [Authorize(Roles = "Admin")]
        public ActionResult CreatePayment()
        {
            return View();
        }

        // GET: Customers/CreateBilling
        [AllowAnonymous]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateBilling()
        {
            return View();
        }

        // GET: Customers/CreateShipping
        [AllowAnonymous]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateShipping()
        {
            return View();
        }

        // GET: Customers/CreateGeneral'
        [AllowAnonymous]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateGeneral()
        {
            return View();
        }

        // GET: Customers/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
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

        // GET: Customers/Details/5
        [Authorize(Roles = "Customer")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var customers = db.Customers.Include(c => c.ShippingAddress).Include(c => c.BillingAddress).Include(c => c.PaymentInformation);
            Customer customer = customers.Where(c => c.Id == id) as Customer;

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }


        /**************************************
         * these are all of the create events *
        **************************************/
        // POST: Customers/CreatePayment
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [Authorize(Roles = "Admin")]
        public ActionResult CreatePayment(
            [Bind(Include = "PaymentInformationId,PaymentInformation")] Customer customer)
        {
            TempData["payment"] = customer.PaymentInformation;
            return RedirectToAction("CreateBilling");
        }

        // POST:Customers/CreateShipping
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateShipping(
            [Bind(Include = "ShippingAddressId,ShippingAddress")] Customer customer)
        {
            TempData["shipping"] = customer.ShippingAddress;
            return RedirectToAction("CreatePayment");
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateGeneral(
            [Bind(Include = "Id,FirstName,LastName,PhoneNumber")] Customer customer)
        {
            TempData["first"] = customer.FirstName;
            TempData["last"] = customer.LastName;
            TempData["phone"] = customer.PhoneNumber;
             
            return RedirectToAction("CreateShipping");
        }

        // POST: Customers/CreateBilling
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [Authorize(Roles = "Admin")]
        public ActionResult CreateBilling(
            [Bind(Include = "BillingAddressId,BillingAddress")] Customer customer)
        {
            // define the address and payment models
            BillingAddress billing = customer.BillingAddress;
            ShippingAddress shipping = (ShippingAddress)TempData["shipping"];
            PaymentInformation payment = (PaymentInformation)TempData["payment"];

            // define the customer model
            customer.FirstName = TempData["first"].ToString();
            customer.LastName = TempData["last"].ToString();
            customer.PhoneNumber = TempData["phone"].ToString();
            customer.EmailAddress = TempData["email"].ToString();

            customer.ShippingAddress = shipping;
            customer.PaymentInformation = payment;

            // add the customer data to the database
            db.BillingAddresses.Add(billing);
            db.ShippingAddresses.Add(shipping);
            db.PaymentInformation.Add(payment);
            db.Customers.Add(customer);

            // save the changes and redirect to the index
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        /**************************************
         * these are the edit / delete events *
        **************************************/
        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Customer")]
        public ActionResult Edit(
            [Bind(Include = "Id,FirstName,LastName,PhoneNumber,EmailAddress,BillingAddressId,BillingAddress,ShippingAddressId,ShippingAddress,PaymentInformationId,PaymentInformation")] Customer customer,
            int? id)
        {
            // define the address and payment models
            BillingAddress billing = customer.BillingAddress;
            ShippingAddress shipping = customer.ShippingAddress;
            PaymentInformation payment = customer.PaymentInformation;

            // get the address and payment model ids
            int billingId = db.Customers.Where(c => c.Id == id).Select(c => c.BillingAddressId).FirstOrDefault();
            int shippingId = db.Customers.Where(c => c.Id == id).Select(c => c.ShippingAddressId).FirstOrDefault();
            int paymentId = db.Customers.Where(c => c.Id == id).Select(c => c.PaymentInformationId).FirstOrDefault();

            // set the address and payment model ids
            billing.Id = billingId;
            shipping.Id = shippingId;
            payment.Id = paymentId;

            customer.BillingAddressId = billingId;
            customer.ShippingAddressId = shippingId;
            customer.PaymentInformationId = paymentId;
           
            if (ModelState.IsValid)
            {
                // update the customer data in the database
                db.Entry(billing).State = EntityState.Modified;
                db.Entry(shipping).State = EntityState.Modified;
                db.Entry(payment).State = EntityState.Modified;
                db.Entry(customer).State = EntityState.Modified;

                // save the changes and redirect to the index
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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

        [Authorize(Roles = "Admin")]
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
