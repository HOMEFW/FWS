using FWS.Dao.Volcano;
using FWS.Ent.Volcano;

namespace FWS.Neg.Volcano
{
    public class nLancamentoGrupo : nBaseGen<eLancamentoGrupo>
    {
        public nLancamentoGrupo()
            : base()
        {
            dao = new dLancamentoGrupo();
        }
        
    }
}
