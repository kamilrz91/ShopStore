using Ninject;
using ShopStore.Dal.Interfaces;
using ShopStore.Dal.ShopStore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;
    
namespace ShopStore.NinjectBinding
{

    public class NinjectDependency : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependency(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IProductRepository>().To<ProductRepository>();
        }
    }
}


