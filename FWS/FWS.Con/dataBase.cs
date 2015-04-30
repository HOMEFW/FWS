using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using FWS.Dic;
using FWS.Log;

namespace FWS.Con
{
    public enum dataType
    {
        Log,
        Persona
    }

    public class dataBase : IDisposable
    {
        private readonly string _strConexao = "";

        private SqlConnection _sqlConn { get; set; }
        private SqlTransaction _sqlTrans = null;
        public bool CommitTrans = true;

        public dataBase(dataType tipoBase, bool conectar = true, bool sqlTransaction = false)
        {
            _strConexao = GetConnectionString(tipoBase);

            if (_strConexao.Equals(""))
            {
                appLog.LogMe(erro.Critical, null, GetType(), mError.InformacaoConexaoBanco);
                throw new Exception(mError.InformacaoConexaoBanco);
            }

            if (conectar)
                AbreConexao(sqlTransaction);
        }

        /// <summary>
        /// Identifica a connectionString que deve ser utilizada.
        /// </summary>
        /// <param name="tipoBase">Tipo de Conexao a ser utilizada</param>
        /// <returns>ConnectionString</returns>
        private static string GetConnectionString(dataType tipoBase)
        {
            var conn = "";
            switch (tipoBase)
            {
                    // Identifica a connectionString para a geração do log
                case dataType.Log:
                    //var config = (Noodles.Log.LogSection)ConfigurationManager.GetSection("log");
                    //conn = (config.Connection.Value ?? "");
                    break;
                case dataType.Persona:
                    conn = (ConfigurationManager.ConnectionStrings["noodle"].ToString() ?? "");
                    break;
            }
            return conn;
        }

        /// <summary>
        /// Abre uma conexão com o banco de dados.
        /// </summary>
        private void AbreConexao(bool sqlTransaction = false)
        {
            try
            {
                _sqlConn = new SqlConnection { ConnectionString = _strConexao };
                _sqlConn.Open();
                if (sqlTransaction)
                    _sqlTrans = _sqlConn.BeginTransaction();
            }
            catch (Exception ex)
            {
                CommitTrans = false;
                appLog.LogMe(erro.Critical, ex, GetType(), mError.BancoNaoEncontrado);
                throw new Exception(mError.BancoNaoEncontrado);
            }
        }


        /// <summary>
        /// Executa um comando Sql
        /// </summary>
        /// <param name="sqlComm">Comando a ser executado</param>
        /// <param name="sqlTransaction">Informa se a Querie deverá ser executado atravé de uma Transação</param>
        /// <returns>DataReader com resultado da operação</returns>
        public SqlDataReader RetornaDataReader(SqlCommand sqlComm, bool sqlTransaction = false)
        {
            try
            {
                if (_sqlConn == null && !sqlTransaction) AbreConexao();
                
                if (sqlTransaction)
                    sqlComm.Transaction = _sqlTrans;
                else
                    sqlComm.Connection = _sqlConn;

                return sqlComm.ExecuteReader();
            }
            catch (Exception ex)
            {
                if (sqlTransaction) _sqlTrans.Rollback();
                CommitTrans = false;
                appLog.LogMe(erro.Critical, ex, GetType(), mError.ExecucaoQuerie);
                throw new Exception(mError.ExecucaoQuerie);
            }
        }

        /// <summary>
        /// Executa um comando Sql
        /// </summary>
        /// <param name="sqlComm">Comando a ser executado</param>
        /// <param name="sqlTransaction">Informa se a Querie deverá ser executado através de uma Transação</param>
        /// <returns>Data set com resultado da operação</returns>
        public DataSet RetornaDataSet(SqlCommand sqlComm, bool sqlTransaction = false)
        {
            try
            {
                var sqlDap = new SqlDataAdapter();
                var sqlDts = new DataSet();

                if (_sqlConn == null && !sqlTransaction) AbreConexao();

                if (sqlTransaction)
                    sqlComm.Transaction = _sqlTrans;
                else
                    sqlComm.Connection = _sqlConn;

                sqlDap.SelectCommand = sqlComm;
                sqlDap.Fill(sqlDts);
                return sqlDts;
            }
            catch (Exception ex)
            {
                if (sqlTransaction) _sqlTrans.Rollback();
                CommitTrans = false;
                appLog.LogMe(erro.Critical, ex, GetType(), mError.ExecucaoQuerie);
                throw new Exception(mError.ExecucaoQuerie);
            }
        }


        /// <summary>
        /// executa o commando sql
        /// </summary>
        /// <param name="sqlComm">Comando Sql a ser executado</param>
        /// <param name="sqlTransaction">Informa se a Querie deverá ser executado atravé de uma Transação</param>
        /// <returns>True=executado com sucesso | False = Erro durante a execução.</returns>
        public bool ExecuteNonQuery(SqlCommand sqlComm, bool sqlTransaction = false)
        {
            try
            {
                if (_sqlConn == null && !sqlTransaction) AbreConexao();

                if (sqlTransaction)
                    sqlComm.Transaction = _sqlTrans;
                else
                    sqlComm.Connection = _sqlConn;

                var iRet = sqlComm.ExecuteNonQuery();
                return !iRet.Equals(0);
            }
            catch (Exception ex)
            {
                if (sqlTransaction) _sqlTrans.Rollback();
                CommitTrans = false;
                appLog.LogMe(erro.Critical, ex, GetType(), mError.ExecucaoQuerie);
                throw new Exception(mError.ExecucaoQuerie);
            }
        }

        /// <summary>
        /// executa o commando sql e retorna um único valor como resultado
        /// </summary>
        /// <param name="sqlComm">Comando Sql a ser executado</param>
        /// <param name="sqlTransaction">Informa se a Querie deverá ser executado atravé de uma Transação</param>
        /// <returns></returns>
        public object ExecuteScalar(SqlCommand sqlComm, bool sqlTransaction = false)
        {
            
            try
            {
                if (_sqlConn == null && !sqlTransaction) AbreConexao();

                if (sqlTransaction)
                    sqlComm.Transaction = _sqlTrans;
                else
                    sqlComm.Connection = _sqlConn;

                var retorno = sqlComm.ExecuteScalar();
                return retorno;
            }
            catch (Exception ex)
            {
                if (sqlTransaction) _sqlTrans.Rollback();
                CommitTrans = false;
                appLog.LogMe(erro.Critical, ex, GetType(), mError.ExecucaoQuerie);
                throw new Exception(mError.ExecucaoQuerie);
            }
        }

        /// <summary>
        /// Finaliza a conexão com o banco de dados.
        /// </summary>
        private void FechaConexao()
        {
            if (_sqlTrans != null)
            {
                if (CommitTrans)
                    _sqlTrans.Commit();
                else
                    _sqlTrans.Rollback();

                _sqlTrans.Dispose();
            }

            if (_sqlConn == null) return;
            _sqlConn.Close();
            _sqlConn = null;
        }

        public void Dispose()
        {
            FechaConexao();
        }
    }
}
