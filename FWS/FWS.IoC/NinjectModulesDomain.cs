using FWS.Domain.Interfaces.Services;
using FWS.Domain.Services;
using Ninject.Modules;

namespace FWS.IoC
{
    public class NinjectModulesDomain : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof (IServiceBase<>)).To(typeof (ServiceBase<>));
        }
    }
}