using FWS.Application.Interfaces;
using FWS.Application.Services;
using Ninject.Modules;

namespace FWS.IoC
{
    public class NinjectModulesApp : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof (IAppServiceBase<>)).To(typeof (AppServiceBase<>));
        }
    }
}
