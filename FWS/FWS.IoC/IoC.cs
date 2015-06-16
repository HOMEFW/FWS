using Ninject;
using Microsoft.Practices.ServiceLocation;
using CommonServiceLocator.NinjectAdapter.Unofficial;

namespace FWS.IoC
{
    public class IoC
    {
        public IKernel Kernel { get; private set; }

        public IoC()
        {
            Kernel = new StandardKernel(
                new NinjectModulesApp(),
                new NinjectModulesDomain(),
                new NinjectModulesRepository()
                );
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(Kernel));
        }
    }
}
