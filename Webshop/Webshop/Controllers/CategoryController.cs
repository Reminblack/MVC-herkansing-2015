using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webshop.Models;

namespace Webshop.Controllers
{
    [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        private WebshopDbEntities db = new WebshopDbEntities();

        //
        // GET: /Category/

        
        public ActionResult Index()
        {
            List<Category> categories = db.Categories.ToList();

            return View(categories);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CategoryViewModel model, string returnUrl)
        {
            if(db.Categories.First(item => item.CategoryName == model.Name) != null){
                ModelState.AddModelError("", "Name already exists");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                db.Categories.Add(generateCategoryFromModel(model));
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
            Category productToEdit = db.Categories.Find(id);
            return View(productToEdit);
        }

        //
        // GET: /Product/Edit/[id]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model, string returnUrl)
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

                    var currentProduct = db.Categories.Find(model.Id);
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
            
            Category model = db.Categories.Find(id);

            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(Category category, string returnUrl)
        {
            if (category == null)
            {
                RedirectToAction("Index");
            }

            if (ModelState.IsValid && db.Products.Where(item => item.category_id == category.Id).Count() > 0)
            {
                ModelState.AddModelError("", "Er zijn producten die bij deze categorie horen.");
                return View(category);
            }

            Category productToDelete = db.Categories.Find(category.Id);
            db.Categories.Remove(productToDelete);
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Details(int id)
        {
            Category model = db.Categories.Find(id);

            return View(model);
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

        private Category generateCategoryFromModel(CategoryViewModel model)
        {
            Category category = new Category();
            category.CategoryName = model.Name;

            return category;
        }
    }
}
