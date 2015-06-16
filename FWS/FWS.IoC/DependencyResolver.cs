using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;

namespace FWS.IoC
{
    public class Dependencies : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public Dependencies()
        {
            var ioc = new IoC();
            _kernel = ioc.Kernel;
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}
