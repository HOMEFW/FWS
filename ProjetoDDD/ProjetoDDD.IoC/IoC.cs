
using CommonServiceLocator.NinjectAdapter.Unofficial;
using Ninject;
using Microsoft.Practices.ServiceLocation;

namespace ProjetoDDD.IoC
{
    public class IoC
    {
        public IKernel kernel { get; private set; }
        public IoC()
        {
            kernel = new StandardKernel(
                new NinjectsModulesApplication(),
                new NinjectsModulesDomain(),
                new NinjectsModulesRepository()
                );

            ServiceLocator.SetLocatorProvider(() => new  NinjectServiceLocator(kernel));
        }
    }
}
