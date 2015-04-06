﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.Models;

namespace Webshop.Controllers
{
    public class AdminController : Controller
    {
        private WebshopDbEntities db = new WebshopDbEntities();

        //
        // GET: /Admin/

        public ActionResult Index()
        {
            List<Product> products = db.Products.ToList();
            return View(products);
            //return RedirectToAction("Index", "Product");
        }

    }
}
