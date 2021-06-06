using ShopStore.Dal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopStore.Dal.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> User { get; set; }
    }
}
