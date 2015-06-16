using System.Collections.Generic;
using FWS.Domain.Entities.Comum;

namespace FWS.Application.Interfaces.Comum
{
    public interface IDominoApp : IAppServiceBase<eDominio>
    {
        IEnumerable<eDominio> GetByName(string dominio);
    }
}
