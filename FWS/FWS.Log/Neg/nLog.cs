using FWS.Log.Dic;
using FWS.Log.Ent;

namespace FWS.Log.Neg
{
    internal class nLog
    {
        internal static eRetorno DoLog(eConfig config, eLog log)
        {
            var retorno = new eRetorno();
            switch (config.LogType)
            {
                case provider.All:
                    retorno = nSqlLog.DoLog(config, log);
                    return !retorno.sucesso ? retorno : nTextLog.DoLog(config, log);

                case provider.Sql:
                    return nSqlLog.DoLog(config, log);

                case provider.Text:
                    return nTextLog.DoLog(config, log);
                
                case provider.SqlonErrorText:
                    retorno = nSqlLog.DoLog(config, log);
                    return !retorno.sucesso ? nTextLog.DoLog(config, log) : retorno;

                default:
                    retorno.sucesso = false;
                    retorno.mensagem = Error.ProviderNaoInformado;
                    return retorno;
            }
        }
    }
}
