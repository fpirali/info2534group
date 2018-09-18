using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Controllers
{
    [Authorize]
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

        [AllowAnonymous]
        // GET: Cart
        public ActionResult Index()
        {
            var viewModel = new Models.CartViewModel()
            {
                Cart = (Models.Cart)Session["shoppingCart"]
            };

            return View(viewModel);
        }

        [AllowAnonymous]
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
            var viewModel = new PaymentInformation();
            viewModel.ExpirationYear = DateTime.Now.Year;
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CompleteOrder(PaymentInformation model)
        {
            if (ModelState.IsValid)
            {
                var vm = new CompleteOrderViewModel()
                {
                    Cart = model.Cart
                };

                Session["shoppingCart"] = new Cart();
                return View(vm);
            }
            else
            {
                var viewModel = new PaymentInformation();
                viewModel.ExpirationYear = DateTime.Now.Year;
                return View("Checkout", viewModel);
            }            
        }
    }
}