using System;
using System.Collections.Generic;
using FWS.Domain.Entities.Financeira;

namespace FWS.Domain.Interfaces.Repositories.Financeira
{
    public interface ILancamentoRepository : IRepositoryBase<eLancamento>
    {
        IEnumerable<eLancamento> FindByDate(DateTime date);
        IEnumerable<eLancamento> FindByDateInterval(DateTime startDate, DateTime endDate);
    }
}
