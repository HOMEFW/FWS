using System;
using System.Text;
using FWS.Helper.Entities;

namespace FWS.Helper.Exceptions
{
    public static class Excecao
    {
        public static string TratarMensagem(Exception ex)
        {            
            StringBuilder sbMensagem = sbMensagem = new StringBuilder();
            
            try
            {
                sbMensagem.AppendFormat("{0}: [", Dictionary.Exceptions.OcorreuExcecao);

                if (ex != null)
                {
                    sbMensagem.AppendFormat("{0}: {1} ,",  Dictionary.Exceptions.Mensagem, ex.Message);

                    if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
                    {
                        sbMensagem.AppendFormat("{0}: {1} ", Dictionary.Exceptions.MensagemInterna, ex.InnerException.Message);
                    }
                }

                sbMensagem.Append(" ]");
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
            finally
            {
                ex = null;
            }

            return sbMensagem.ToString();
        }

        public static eRetorno TratarRetorno(Exception ex) 
        {
            var retorno = new eRetorno
            {
                OperacaoRealizadaComSucesso = false,
                OcorreuExcessao = true,
                MensagemErro = TratarMensagem(ex),
                MensagemSucesso = null
            };
            return retorno;
        }

    }
}
    