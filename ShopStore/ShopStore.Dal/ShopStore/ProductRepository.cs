using ShopStore.Dal.Interfaces;
using ShopStore.Dal.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopStore.Dal.ShopStore
{
    public class ProductRepository : IProductRepository
    {
        private ShopStoreContext context = new ShopStoreContext();
        static ProductRepository()
        {
            Database.SetInitializer<ShopStoreContext>(null);
        }
        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }


        public void SaveProduct(Product product)
        {

            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.Find(product.ProductID);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;

                }
            }
            context.SaveChanges();
        }

        public Product DeleteProduct(int productID)
        {
            Product dbEntry = context.Products.Find(productID);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

        public int? GetCategoryId(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;
           var categoryId = context.Category.FirstOrDefault(x => x.Name == name).CategoryId;
           return categoryId;
        }
    }
}