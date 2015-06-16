
using System.Collections.Generic;
using FWS.Domain.Entities.Comum;
using FWS.Domain.Interfaces.Repositories.Comum;
using FWS.Domain.Interfaces.Services.Comum;

namespace FWS.Domain.Services.Comum
{
    public class DominioService : ServiceBase<eDominio>, IDominioService
    {
        private readonly IDominioRepository _repository;

        public DominioService(IDominioRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<eDominio> GetByName(string dominio)
        {
            return _repository.GetByName(dominio);
        }
    }
}
