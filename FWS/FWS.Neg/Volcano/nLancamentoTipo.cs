using FWS.Dao.Volcano;
using FWS.Ent.Volcano;

namespace FWS.Neg.Volcano
{
    public class nLancamentoTipo : nBaseGen<eLancamentoTipo>
    {
        public nLancamentoTipo() : base()
        {
           dao = new DLancamentoTipo();
        }
    }
}
