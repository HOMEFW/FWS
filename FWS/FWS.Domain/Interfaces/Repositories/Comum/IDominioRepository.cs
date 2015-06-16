using System.Collections.Generic;
using FWS.Domain.Entities.Comum;

namespace FWS.Domain.Interfaces.Repositories.Comum
{
    public interface IDominioRepository: IRepositoryBase<eDominio>
    {
        IEnumerable<eDominio> GetByName(string dominio);
    }
}
