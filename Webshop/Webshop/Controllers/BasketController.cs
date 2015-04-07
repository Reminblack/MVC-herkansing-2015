using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using Webshop.Filters;
using Webshop.Models;

namespace Webshop.Controllers
{

    [InitializeSimpleMembership]
    public class BasketController : Controller
    {
        private WebshopDbEntities db = new WebshopDbEntities();

        //
        // GET: /Basket/

        public ActionResult Index()
        {
            OrderInfo orderInfo = db.OrderInfoes.FirstOrDefault(item => (item.UserId == (int)WebSecurity.CurrentUserId) && (item.OrderStatus == 0));
            if (orderInfo != null)
            {
                List<Lt_OrderProduct> orders = db.Lt_OrderProduct.Where(item => item.OrderId == orderInfo.Id).ToList();

                List<Product> products = new List<Product>();
                foreach (Lt_OrderProduct p in orders)
                {
                    products.Add(db.Products.Find(p.ProductId));
                }


                return View(products);
            }
            return RedirectToAction("OrderError", "Basket");
        }

        public ActionResult Add(int productId, int quantity = 1)
        {
            Product product = db.Products.Find(productId);
            
            OrderInfo orderInfo = db.OrderInfoes.FirstOrDefault(item => (item.UserId == (int)WebSecurity.CurrentUserId) && (item.OrderStatus == 0));

            //IF NO Order exists && orderHasStatus 0!
            if (orderInfo == null)
            {
                //Generate new Order
                orderInfo = newOrder();
            }
            else
            {
                Lt_OrderProduct existingOrder = db.Lt_OrderProduct.FirstOrDefault(item => item.ProductId == productId);
                if(existingOrder != null){
                    existingOrder.Quantity += quantity;
                    return RedirectToAction("Index");
                }
            }

            //Generate Order_Product
            Lt_OrderProduct order_Products = new Lt_OrderProduct();

            order_Products.OrderId = orderInfo.Id;
            order_Products.ProductId = product.Id;
            order_Products.Quantity = quantity;

            db.Lt_OrderProduct.Add(order_Products);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Order()
        {
            return View();
        }

        

        [HttpPost]
        [InitializeSimpleMembership]
        [ValidateAntiForgeryToken]
        public ActionResult Order(string returnUrl)
        {
            OrderInfo orderInfo = db.OrderInfoes.FirstOrDefault(item => (item.UserId == (int)WebSecurity.CurrentUserId) && (item.OrderStatus == 0));

            orderInfo.OrderStatus = 1;
            db.Entry(orderInfo).CurrentValues.SetValues(orderInfo);
            db.SaveChanges();

            Mailman.SendMail("noreply@furnitureWebsop.com", db.UserEmails.First(item => item.UserId == (int)WebSecurity.CurrentUserId).Email, "Order at FurnitureWebshop", "You have ordered some Furniture");

            return RedirectToAction("Index", "Home");
        }

        public ActionResult OrderError()
        {
            return View();
        }

        public OrderInfo newOrder()
        {
            OrderInfo newOrderInfo = new OrderInfo();
            newOrderInfo.UserId = (int)WebSecurity.CurrentUserId;
            db.OrderInfoes.Add(newOrderInfo);
            db.SaveChanges();
            return newOrderInfo;
        }

    }
}
