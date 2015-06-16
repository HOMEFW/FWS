using System.Collections.Generic;
using FWS.Application.Interfaces.Comum;
using FWS.Domain.Entities.Comum;
using FWS.Domain.Interfaces.Services.Comum;

namespace FWS.Application.Services.Comum
{
    public class DominioAppService : AppServiceBase<eDominio>, IDominoApp
    {
        private readonly IDominioService _service;

        public DominioAppService(IDominioService dominio)
            : base(dominio)
        {
            _service = dominio;
        }


        public IEnumerable<eDominio> GetByName(string dominio)
        {
            return _service.GetByName(dominio);
        }
    } 
}
