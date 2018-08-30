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
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Product
        public ActionResult Index()
        {
            var productModels = db.ProductModels.Include(p => p.Category).Include(p => p.Pet);
            return View(productModels.ToList());
        }

        // GET: Products on sale
        public ActionResult IndexSale()
        {
            var products = db.ProductModels.Include(p => p.Category).Include(p => p.Pet).Where(p => p.OnSale == true);
            return View(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductModels productModels = db.ProductModels.Find(id);
            if (productModels == null)
            {
                return HttpNotFound();
            }
            return View(productModels);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(db.Categories, "Id", "Name");
            ViewBag.Pets = new SelectList(db.Pets, "Id", "Type");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,CategoryId,PetId,Price,ImageFilePath,OnSale")] ProductModels productModels)
        {
            if (ModelState.IsValid)
            {
                db.ProductModels.Add(productModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(db.Categories, "Id", "Name", productModels.CategoryId);
            ViewBag.Pets = new SelectList(db.Pets, "Id", "Type", productModels.PetId);
            return View(productModels);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductModels productModels = db.ProductModels.Find(id);
            if (productModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = new SelectList(db.Categories, "Id", "Name", productModels.CategoryId);
            ViewBag.Pets = new SelectList(db.Pets, "Id", "Type", productModels.PetId);
            return View(productModels);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,CategoryId,PetId,Price,ImageFilePath,OnSale")] ProductModels productModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = new SelectList(db.Categories, "Id", "Name", productModels.CategoryId);
            ViewBag.Pets = new SelectList(db.Pets, "Id", "Type", productModels.PetId);
            return View(productModels);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductModels productModels = db.ProductModels.Find(id);
            if (productModels == null)
            {
                return HttpNotFound();
            }
            return View(productModels);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductModels productModels = db.ProductModels.Find(id);
            db.ProductModels.Remove(productModels);
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
