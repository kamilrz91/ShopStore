using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopStore.Dal.Repository
{
    [Table("Category")]
    public class Category
    {
        [ForeignKey("Product")]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Product Product { get; set; }
    }
}
