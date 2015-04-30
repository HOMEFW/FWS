using System;
using FWS.Ent;

namespace FWS.Hlp
{
    public static class hRetorno
    {
        public static eMensagem Retorno(bool? sucesso = null, Exception ex = null)
        {
            return new eMensagem() { sucesso = (sucesso ?? true), mensagem = (ex != null ? ex.Message : "") };
        }
    }
}
