using System.Collections.Generic;
using FWS.Domain.Entities.Comum;

namespace FWS.Domain.Interfaces.Services.Comum
{
    public interface IDominioService: IServiceBase<eDominio>
    {
        IEnumerable<eDominio> GetByName(string dominio);
    }
}
