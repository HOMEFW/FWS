using System;
using System.Linq;
using FWS.Dao.Context;
using FWS.Ent.Volcano;

namespace FWS.Dao.Volcano
{
    public class DLancamentoTipo: dBaseGen<eLancamentoTipo, FwsVolcanoContext>
    {
        public override IQueryable<eLancamentoTipo> ListarRegistrosComFiltro(eLancamentoTipo filtro)
        {
            throw new NotImplementedException();
        }
    }
}
                                                                                                                                                                                        