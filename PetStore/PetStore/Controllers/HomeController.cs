using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetStore.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        protected ApplicationDbContext db { get; set; }
        public HomeController()
        {
            this.db = new ApplicationDbContext();
        }
        
        public ActionResult Index()
        {
            var user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
            if (Session["shoppingCart"] == null)
            {
                System.Web.HttpContext.Current.Session.Add($"shoppingCart", new Cart() { IsPaid = false, Products = new List<ProductModels>(), UserId = user });
            }
            
            return View();
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}