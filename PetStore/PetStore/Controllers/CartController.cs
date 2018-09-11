using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Controllers
{
    public class CartController : Controller
    {
        protected Cart Cart
        {
            get
            {
                return (Cart)Session["shoppingCart"];
            }
        }
        protected Models.ApplicationDbContext db { get; set; }
        public CartController()
        {
            db = new Models.ApplicationDbContext();
        }

        // GET: Cart
        public ActionResult Index()
        {
            var viewModel = new Models.CartViewModel()
            {
                Cart = (Models.Cart)Session["shoppingCart"]
            };

            return View(viewModel);
        }

        public void Add(int id)
        {
            var product = db.ProductModels.Find(id);

            if (Cart == null)
            {
                Session.Add("shoppingCart", new Cart()); 
            }

            Cart.Products.Add(product);
        }

        public ActionResult Checkout()
        {

            return View();
        }
    }
}