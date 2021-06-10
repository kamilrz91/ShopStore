using ShopStore.Dal.Interfaces;
using ShopStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopStore.Controllers
{
    public class ProductController : Controller
    {
        public ProductController()
        {

        }
        private readonly IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult List(string category, int page = 1)
        {
            var categoryId = repository.GetCategoryId(category); 
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
               .Where(p => category == null || p.Category == categoryId)
               .OrderBy(p => p.ProductID)
               .Skip((page - 1) * PageSize)
               .Take(PageSize),
                PagingInfo = new InformationPage
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        repository.Products.Count() : 
                    repository.Products.Where(e => e.Category == categoryId).Count()
                },
                CurrentCategory = category
            };
            return View(model);
                }

    }
}
