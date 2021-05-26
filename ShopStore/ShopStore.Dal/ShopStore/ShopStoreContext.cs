using ShopStore.Dal.Repository;
using System.Data.Entity;

namespace ShopStore.Dal.ShopStore
{
    public class ShopStoreContext: DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<User> User { get; set; }
    }
}
