using FWS.Data.Repositories;
using FWS.Domain.Interfaces.Repositories;
using Ninject.Modules;

namespace FWS.IoC
{
    public class NinjectModulesRepository:NinjectModule
    {
        public override void Load()
        {
            Bind(typeof (IRepositoryBase<>)).To(typeof (RepositoryBase<>));
        }
    }
}
