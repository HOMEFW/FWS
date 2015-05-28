using Ninject.Modules;
using ProjetoDDD.Application;
using ProjetoDDD.Application.Interface;
using ProjetoDDD.Domain.Interfaces.Repositories;
using ProjetoDDD.Domain.Interfaces.Services;
using ProjetoDDD.Domain.Services;
using ProjetoDDD.Infra.Data.Repositories;

namespace ProjetoDDD.IoC
{

    public class NinjectsModulesApplication : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            Bind<IClienteAppService>().To<ClienteAppService>();
            Bind<IProdutoAppService>().To<ProdutoAppService>();
        }
    }
    public class NinjectsModulesDomain : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            Bind<IClienteService>().To<ClienteService>();
            Bind<IProdutoService>().To<ProdutoService>();
        }
    }

    public class NinjectsModulesRepository : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof (IRepositoryBase<>)).To(typeof (RepositoryBase<>));
            Bind<IClienteRepository>().To<ClienteRepository>();
            Bind<IProdutoRepository>().To<ProdutoRepository>();
        }
    }
}
