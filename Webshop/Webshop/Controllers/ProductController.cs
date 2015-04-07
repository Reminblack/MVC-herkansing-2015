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
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductViewModel model, string returnUrl)
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

        #region edit
        public ActionResult Edit(int id, string returnUrl)
        {
            Product productToEdit = db.Products.Find(id);
                return View(productToEdit);
            
            return RedirectToLocal(returnUrl); 
        }

        //
        // GET: /Product/Edit/[id]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product model, string returnUrl)
        {
            if (model == null)
            {
                return RedirectToLocal(returnUrl); 
            }

            //model.Price = model.Price;
            if (ModelState.IsValid)
            {
                try
                {
                    //Product productToEdit = db.Products.First(product => product.Id == (int)this.RouteData.Values["id"]);

                    var currentProduct = db.Products.Find(model.Id);
                    db.Entry(currentProduct).CurrentValues.SetValues(model);
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
        #endregion


        public ActionResult Remove(int id)
        {
            Product model = db.Products.Find(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(Product product, string returnUrl)
        {
            if (ModelState.IsValid && product != null)
            {
                Product productToDelete = db.Products.Find(product.Id);
                db.Products.Remove(productToDelete);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Product");
        }


        public ActionResult Details(int id)
        {
            Product model = db.Products.Find(id);

            return View(model);
        }

        public ActionResult AddToBasket(int id)
        {
            Product model = db.Products.Find(id);

            return RedirectToAction("Add", "Basket", new {product = model});
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

        private Product generateProductFromModel(ProductViewModel model){
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
