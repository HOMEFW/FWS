using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using FWS.Log.Dic;
using FWS.Log.Ent;

namespace FWS.Log.Dao
{
    internal class connection : IDisposable
    {
        private SqlConnection SqlConn { get; set; }

        public connection(eConfig config, out eRetorno retorno)
        {
            retorno = new eRetorno();
            try
            {
                var strConexao = ConfigurationManager.ConnectionStrings[config.ConnectionStringName].ToString();

                if (strConexao.Equals(""))
                    throw new Exception(Error.InformacaoConexaoBanco);

                SqlConn = new SqlConnection {ConnectionString = strConexao};
                try
                {
                    SqlConn.Open();
                }
                catch
                {
                    CreateDataBase(config, out retorno);
                }
                
                if (!SqlConn.State.Equals(ConnectionState.Open))
                    SqlConn.Open();

                retorno.sucesso = true;
            }
            catch (Exception ex)
            {
                retorno.sucesso = false;
                retorno.mensagem = Error.BancoNaoEncontrado + " | " + ex.Message;
            }
        }

        /// <summary>
        /// executa o commando sql
        /// </summary>
        /// <param name="sqlComm">Comando Sql a ser executado</param>
        /// <returns>True=executado com sucesso | False = Erro durante a execução.</returns>
        public eRetorno ExecuteNonQuery(SqlCommand sqlComm)
        {
            var retorno = new eRetorno();
            try
            {
                sqlComm.Connection = SqlConn;
                var iRet = sqlComm.ExecuteNonQuery();
                retorno.sucesso = !iRet.Equals(0);
            }
            catch(Exception ex)
            {
                retorno.sucesso = false;
                retorno.mensagem = Error.BancoNaoEncontrado + " | " + ex.Message;
            }
            return retorno;
        }

        /// <summary>
        /// Finaliza a conexão com o banco de dados.
        /// </summary>
        public void Dispose()
        {
            if (SqlConn == null) return;
            SqlConn.Close();
            SqlConn = null;
        }

        internal object ExecuteScalar(SqlCommand sqlComm, out eRetorno retorno)
        {
            retorno = new eRetorno() {sucesso = true};
            try
            {
                sqlComm.Connection = SqlConn;
                var iRet = sqlComm.ExecuteScalar();
                return iRet;
            }
            catch (Exception ex)
            {
                retorno.sucesso = false;
                retorno.mensagem = Error.BancoNaoEncontrado + " | " + ex.Message;
            }
            return retorno;
        }


        internal void CreateDataBase(eConfig config, out eRetorno retorno)
        {
            retorno =  new eRetorno();
            string strConn = "", strDataBaseName = "";
            var strSplit = ConfigurationManager.ConnectionStrings[config.ConnectionStringName].ToString().Split(';');
            foreach (var item in strSplit)
                if (item.ToUpper().Contains("INITIAL CATALOG"))
                {
                    strConn += "Initial Catalog=master;";
                    strDataBaseName = item.Replace("Initial Catalog=", "");
                }
                else if (!item.ToUpper().Contains("ATTACHDBFILENAME"))
                    strConn += item + ";";

            var caminho = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
            //AppDomain.CurrentDomain.SetData("DataDirectory", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));

            var newConn =  new SqlConnection(strConn);
            var strSql = "CREATE DATABASE ? ON PRIMARY " +
                         "(NAME = ?, " +
                         "FILENAME = '" + caminho + "\\?.mdf', " +
                         "SIZE = 5MB, MAXSIZE = 100MB, FILEGROWTH = 1%) " +
                         "LOG ON (NAME = ?_Log, " +
                         "FILENAME = '" + caminho + "\\?_Log.ldf', " +
                         "SIZE = 1MB, " +
                         "MAXSIZE = 50MB, " +
                         "FILEGROWTH = 1%)";
            strSql = strSql.Replace("?", strDataBaseName);

            var sqlCommand = new SqlCommand(strSql, newConn);
            try
            {
                newConn.Open();
                sqlCommand.ExecuteNonQuery();
                retorno.sucesso = true;
            }
            catch (Exception ex)
            {
                retorno.sucesso = false;
                retorno.mensagem = ex.Message;
            }
            finally
            {
                if (newConn.State == ConnectionState.Open)
                    newConn.Close();
            }
        }
    }
}
