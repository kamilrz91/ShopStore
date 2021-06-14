using ShopStore.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ShopStore.Controllers
{
    public class NavController : Controller
    {
        public NavController()
        {

        }
        private IProductRepository repository;

        public NavController(IProductRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string category = null)
        {
            var categoryId = repository.GetCategoryId(category);

            ViewBag.SelectedCategory = category;


            IEnumerable<string> categories = repository.Categories
                        .Where(p => category == null || p.CategoryId == categoryId)
                        .Distinct()
                        .Select(x=>x.Name)
                        .OrderBy(x => x);

           
            return PartialView("FlexMenu", categories);
        }

        public ActionResult List(string s)
        {
            return RedirectToAction("List", "Product");
        }
    }
}
