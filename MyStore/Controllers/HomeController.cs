using Microsoft.AspNet.Identity;
using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyStore.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult Index(string message)
        {
            ViewBag.Message = message;
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
        public ActionResult Products()
        {
            List<Product> products = db.Products.Include(p => p.Type).Include(p => p.Category).ToList();
            return PartialView(products);
        }

        public JsonResult AddToCart(int id)
        {
            Product product = db.Products.Include(p => p.Type).Include(p => p.Category).SingleOrDefault(p => p.Id == id);
            if(Session["MyCart"] == null)
            {
                Session["MyCart"] = new List<Product>();
            }
            ((List<Product>)Session["MyCart"]).Add(product);

            return new JsonResult { Data = "You have add a "+product.Name +" successfully to your cart!", JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult MyCart()
        {
            List<Product> products = new List<Product>();
            float total = 0f;
            if (Session["MyCart"] != null)
            {
                products = (List<Product>)Session["MyCart"];
                foreach (var prd in products)
                {
                    total = total + prd.Price;
                }
                ViewBag.Total = total;
            }
            //Take products stored in Session. 
            return View(products);
        }


        public ActionResult SubmitOrder()
        {
            List<Product> products = new List<Product>();
            Order order = new Order();
            if (Session["MyCart"] != null)
            {
                products = (List<Product>)Session["MyCart"];
            }
            if (products.Count > 0)
            {
                foreach(var prd in products)
                {
                    order.TotalPrice = order.TotalPrice + prd.Price;
                }
                order.User = User.Identity.GetUserName();
                order.Status = "Confirmed";
                db.Orders.Add(order);
                db.SaveChanges();
                ViewBag.Order = order.Id;
                return View();
            } else
            {

                return HttpNotFound();
            }
        }
    }
}