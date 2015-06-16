using System;
using System.Linq;
using FWS.Dao.Context;
using FWS.Ent.Volcano;

namespace FWS.Dao.Volcano
{
    public class dLancamentoGrupo : dBaseGen<eLancamentoGrupo, FwsVolcanoContext>
    {
        public dLancamentoGrupo()
            : base()
        {
        }

        public override IQueryable<eLancamentoGrupo> ListarRegistrosComFiltro(eLancamentoGrupo filtro)
        {
            throw new NotImplementedException();
        }
    }
}
