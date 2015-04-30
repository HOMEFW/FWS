using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using FWS.Log.Ent;
using FWS.Log.Scripts;

namespace FWS.Log.Dao
{
    internal class dLog : IDisposable
    {

        private static void ValidarDataBase(connection conexao, out eRetorno retorno)
        {
            var ret =
                (string) conexao.ExecuteScalar(new SqlCommand() {CommandText = sScript.FWSBUSTED_CREATE}, out retorno);

            if (retorno.sucesso && ret.Equals("T"))
                retorno = conexao.ExecuteNonQuery(new SqlCommand() {CommandText = sScript.USP_01_INSERT_BUSTED_CREATE});
        }

        internal eRetorno GravaLog(eConfig config, eLog log)
        {
            var retorno = new eRetorno() {sucesso = true};
            try
            {
                var sqlComm = new SqlCommand
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "USP_01_INSERT_BUSTED"
                };
                var logInfo = log.GetType().GetProperties();

                foreach (var propertyInfo in logInfo.Where(propertyInfo => propertyInfo.GetValue(log) != null))
                    sqlComm.Parameters.Add(new tratamentoDados().tratarParamentros(log, propertyInfo));

                using (var conexao = new connection(config, out retorno))
                    if (retorno.sucesso)
                    {
                        ValidarDataBase(conexao, out retorno);
                        if (retorno.sucesso)
                            retorno = conexao.ExecuteNonQuery(sqlComm);
                    }

            }
            catch (Exception ex)
            {
                retorno.sucesso = false;
                retorno.mensagem = ex.Message;
            }
            return retorno;
        }

        public void Dispose()
        {
            GC.Collect();
        }
    }
}
