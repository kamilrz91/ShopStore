using ShopStore.Dal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopStore.Models
{
    public class CartView
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}