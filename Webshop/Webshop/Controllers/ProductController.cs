using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.Models;

namespace Webshop.Controllers
{
    public class ProductController : Controller
    {
        private WebshopDbEntities db = new WebshopDbEntities();
        
        //
        // GET: /Product/

        public ActionResult Index()
        {
            List<Product> products = db.Products.ToList();
            return View(products);
        }

        //
        // GET: /Product/

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductView model, string returnUrl)
        {
            if (ModelState.IsValid)
            {   
                db.Products.Add(generateProductFromModel(model));
                db.SaveChanges();
                return RedirectToLocal(returnUrl);
            }

            // If we got this far, something failed, redisplay form
            //ModelState.AddModelError("", "Microsoft happened.");
            return View(model);
        }

        //
        // GET: /Product/Edit/[]

        public ActionResult Edit(int id)
        {
            Product productToEdit = db.Products.First(product => product.Id == id);

            return View(productToEdit);
        }

        //
        // GET: /Product/Edit/[id]

        public ActionResult Edit(ProductView model, int id, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Product productToEdit = db.Products.First(product => product.Id == id);

                    db.Products.Remove(productToEdit);
                    db.Products.Add(generateProductFromModel(model));

                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    //Oh no
                }
                    
                return RedirectToLocal(returnUrl);
            }

            return View(model);
        }

        //
        // GET: /Product/Delete/[id]

        public ActionResult Remove(int itemToDelete)
        {
            Product productToDelete = db.Products.First(product => product.Id == itemToDelete);
            db.Products.Remove(productToDelete);
            db.SaveChanges();

            return RedirectToAction("Index", "Product");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        private Product generateProductFromModel(ProductView model){
            Product product = new Product();
            product.Name = model.Name;
            product.Image = model.Image;
            product.Description = model.Description;
            product.Price = model.Price;
            product.Stock = model.Stock;
            
            return product;
        }
    }
}
