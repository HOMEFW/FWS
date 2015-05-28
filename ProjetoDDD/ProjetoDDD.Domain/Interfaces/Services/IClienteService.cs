using System.Collections.Generic;
using ProjetoDDD.Domain.Entities;

namespace ProjetoDDD.Domain.Interfaces.Services
{
    public interface IClienteService: IServiceBase<Cliente>
    {
        IEnumerable<Cliente> ObterClientesEspeciais(IEnumerable<Cliente> cliente);
    }
}
