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
            return View(db.ProductModels.ToList());
        }

        // GET: Products on sale
        public ActionResult IndexSale()
        {
            var sales = db.ProductModels.Where(m => m.Markdown > 0).ToList();
            return View(sales);
        }

        // GET: Products by category
        public ActionResult BrowseCategories(int id)
        {
            var products = db.ProductModels.Where(m => m.CategoryId == id).ToList();
            return View(products);
        }

        // GET: Products by pet type
        public ActionResult BrowsePets(int id)
        {
            var products = db.ProductModels.Where(m => m.PetId == id).ToList();
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
            var categories = GetAllCategories();
            var pets = GetAllPets();
            var model = new ProductModels();

            model.Categories = GetSelectListItems(categories);
            model.Pets = GetSelectListItems(pets);
            return View(model);

            //ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId");
            //return View();
        }

        // this takes a list of strings and returns a list of select list items to render the drop down list with
        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> items)
        {
            var list = new List<SelectListItem>();
            foreach(var v in items)
            {
                list.Add(new SelectListItem { Value = v , Text = v });
            }
            return list;
        }

        // this will get all pet types from the db and return them as a list of strings
        private IEnumerable<string> GetAllPets()
        {
            List<string> list = new List<string>();
            foreach(var v in db.Pets)
            {
                list.Add(v.Type);
            }
            return list;
        }

        // this will get all categories from the db and return them as a list of strings
        private IEnumerable<string> GetAllCategories()
        {
            List<string> list = new List<string>();
            foreach(var v in db.Categories)
            {
                list.Add(v.Name);
            }
            return list;
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Price,PetId,CategoryId,OnSale,Markdown,ImageFilePath")] ProductModels productModels)
        {
            if (ModelState.IsValid)
            {
                db.ProductModels.Add(productModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

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
            return View(productModels);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description")] ProductModels productModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
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
