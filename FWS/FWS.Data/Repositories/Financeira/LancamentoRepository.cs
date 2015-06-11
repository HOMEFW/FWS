using System;
using System.Collections.Generic;
using FWS.Domain.Entities.Financeira;
using FWS.Domain.Interfaces.Repositories.Financeira;

namespace FWS.Data.Repositories.Financeira
{
    public class LancamentoRepository : RepositoryBase<eLancamento>, ILancamentoRepository
    {
        public IEnumerable<eLancamento> FindByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<eLancamento> FindByDateInterval(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}
