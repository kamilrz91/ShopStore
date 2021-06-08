using ShopStore.Dal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopStore.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public InformationPage PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}