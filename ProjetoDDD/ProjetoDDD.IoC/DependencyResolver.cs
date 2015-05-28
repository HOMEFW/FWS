using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;

namespace ProjetoDDD.IoC
{
    public class Dependencies : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public Dependencies()
        {
            var ioc = new IoC();
            _kernel = ioc.kernel;
        }

        #region IDependencyResolver Members

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        #endregion
    }
}
