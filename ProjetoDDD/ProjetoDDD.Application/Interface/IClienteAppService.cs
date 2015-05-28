using System.Collections.Generic;
using ProjetoDDD.Domain.Entities;

namespace ProjetoDDD.Application.Interface
{
    public interface IClienteAppService : IAppServiceBase<Cliente>
    {
        IEnumerable<Cliente> ObterClientesEspeciais();
    }
}
