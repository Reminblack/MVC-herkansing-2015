using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.Models;

namespace Webshop.Controllers
{
    public class BasketController : Controller
    {
        private WebshopDbEntities1 db = new WebshopDbEntities1();

        //
        // GET: /Basket/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(Product product)
        {
            //db.Lt_OrderProduct.Add();
            return View();
        }

    }
}
