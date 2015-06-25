using System;
using System.Collections.Generic;
using FWS.Domain.Entities.Comum;
using FWS.Domain.Interfaces.Repositories.Comum;

namespace FWS.Data.Repositories.Comum
{
    public class DominioRepository : RepositoryBase<eDominio>, IDominioRepository
    {
        public IEnumerable<eDominio> GetByName(string dominio)
        {
            throw new NotImplementedException();
        }
    }
}
