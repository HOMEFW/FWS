using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using FWS.Helper.Entities;

namespace FWS.Helper.Data
{
    public static class BancoDados
    {
        public static Enumerators.BancoDados.TipoBanco TipoBanco { get; set; }        
        public static Enumerators.BancoDados.TipoComando TipoComando { get; set; }        
        public static eConexaoBanco ConexaoBanco { get; set; }

        private static string _procedure;
        public static string Procedure
        {
            get { return _procedure; }
            set { _procedure = value; }
        }

        private static StringBuilder _sbQuery;
        public static StringBuilder SbQuery
        {
            get { return _sbQuery ?? (_sbQuery = new StringBuilder()); }
            set { _sbQuery = value; }
        }

        private static List<DbParameter> _lstParametros;
        public static List<DbParameter> LstParametros
        {
            get { return _lstParametros ?? (_lstParametros = new List<DbParameter>()); }
            set { _lstParametros = value; }
        }

        private static DbDataReader _dr;
        public static DbDataReader Dr
        {
            get
            {
                if (_dr == null || _dr.IsClosed)
                {
                    if (TipoBanco == Enumerators.BancoDados.TipoBanco.Sql)
                    {
                        _dr = Comando.ExecuteReader();
                    }
                    else if (TipoBanco == Enumerators.BancoDados.TipoBanco.Oracle) 
                    {
                        //Comando.ExecuteNonQuery();
                        //var parametro = LstParametros.Where(q => q.Direction == ParameterDirection.Output).FirstOrDefault();
                        //if (parametro != null)
                        //{
                        //    _dr = ((OracleRefCursor)parametro.Value).GetDataReader();
                        //}
                    }
                }

                return _dr;
            }
            set { _dr = value; }
        }

        private static DbCommand _comando;
        public static DbCommand Comando
        {
            get
            {
                if (TipoComando == Enumerators.BancoDados.TipoComando.Text)
                {
                    if (TipoBanco == Enumerators.BancoDados.TipoBanco.Sql)
                        _comando = new SqlCommand(SbQuery.ToString(), Conexao as SqlConnection);
                    //else if (TipoBanco == Enumeradores.TipoBanco.Oracle)
                    //    _comando = new OracleCommand(SbQuery.ToString(), Conexao as OracleConnection);

                    _comando.CommandType = CommandType.Text;
                }
                else if (TipoComando == Enumerators.BancoDados.TipoComando.StoredProcedure)
                {
                    if (TipoBanco == Enumerators.BancoDados.TipoBanco.Sql)
                        _comando = new SqlCommand(Procedure, Conexao as SqlConnection);
                    //else if (TipoBanco == Enumeradores.TipoBanco.Oracle)
                    //    _comando = new OracleCommand(Procedure, Conexao as OracleConnection);

                    _comando.CommandType = CommandType.StoredProcedure;
                    if (LstParametros != null && LstParametros.Any())
                    {
                        _comando.Parameters.AddRange(LstParametros.ToArray());
                    }
                }

                return _comando;
            }
            set { _comando = value; }
        }

        private static DbConnection _conexao;
        public static DbConnection Conexao
        {
            get
            {
                if (_conexao == null || _conexao.State != ConnectionState.Open)
                {
                    if (TipoBanco == Enumerators.BancoDados.TipoBanco.Sql)
                        _conexao = new SqlConnection(ConexaoBanco.GetConexao);
                    //else if (TipoBanco == Enumeradores.TipoBanco.Oracle)
                    //    _conexao = new OracleConnection(ConexaoBanco.ConexaoOracle);

                    if (_conexao != null) _conexao.Open();
                }

                return _conexao;
            }
            set { _conexao = value; }
        }

        #region Metodos Apoio

        public static byte? ObterBite(string nome, DbDataReader dr)
        {
            byte? valor = null;

            if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                valor = dr.GetByte(dr.GetOrdinal(nome));

            return valor;
        }

        public static int? ObterInt16(string nome, DbDataReader dr)
        {
            int? valor = null;

            if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                valor = dr.GetInt16(dr.GetOrdinal(nome));

            return valor;
        }

        public static int? ObterInt32(string nome, DbDataReader dr)
        {
            int? valor = null;

            if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                valor = dr.GetInt32(dr.GetOrdinal(nome));

            return valor;
        }

        public static long? ObterInt64(string nome, DbDataReader dr)
        {
            long? valor = null;

            if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                valor = Convert.ToInt64(dr[nome]);

            return valor;
        }

        public static decimal? ObterDecimal(string nome, DbDataReader dr)
        {
            decimal? valor = null;

            if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                valor = Convert.ToDecimal(dr[nome]);

            return valor;
        }

        public static string ObterString(string nome, DbDataReader dr)
        {
            string valor = null;

            if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                valor = dr.GetString(dr.GetOrdinal(nome)).Trim();

            return valor;
        }

        public static char? ObterChar(string nome, DbDataReader dr)
        {
            char? valor = null;
            char aux;
            string valorAuxiliar = null;

            valorAuxiliar = ObterString(nome, dr);

            if (!string.IsNullOrEmpty(valorAuxiliar) && char.TryParse(valorAuxiliar, out aux)) 
            {
                valor = aux;
            }

            return valor;
        }

        public static bool? ObterBoleano(string nome, DbDataReader dr)
        {
            bool? valor = false;

            if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                valor = Convert.ToBoolean(dr[nome]);

            return valor;
        }

        public static DateTime? ObterDateTime(string nome, DbDataReader dr)
        {
            DateTime? valor = null;

            if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                valor = dr.GetDateTime(dr.GetOrdinal(nome));

            return valor;
        }

        public static float? ObterFloat(string nome, DbDataReader dr)
        {
            float? valor = null;

            if (dr.IsDBNull(dr.GetOrdinal(nome)) == false)
                valor = dr.GetFloat(dr.GetOrdinal(nome));

            return valor;
        }

        #endregion Metodos Apoio

        public static int ExecuteScalar() 
        {
            var id = 0;

            switch (TipoBanco)
            {
                case Enumerators.BancoDados.TipoBanco.Sql:
                    var valor = Comando.ExecuteScalar();
                    if (valor != null) 
                    {
                        int.TryParse(valor.ToString(), out id);
                    }
                    break;
                case Enumerators.BancoDados.TipoBanco.Oracle:
                {
                    Comando.ExecuteNonQuery();
                    var parametro = LstParametros.FirstOrDefault(q => q.Direction == ParameterDirection.Output);

                    if (parametro == null) return id;
                    
                    if (parametro.Value != null)
                    {
                        int.TryParse(parametro.Value.ToString(), out id);
                    }
                }
                    break;
            }
            return id;
        }

        public static void AdicionarParametro(string nome, object valor, object direcao, object tipo) 
        {
            DbParameter parametro = null;

            try
            {
                if (!string.IsNullOrEmpty(nome) && tipo != null)
                {
                    switch (TipoBanco)
                    {
                        case Enumerators.BancoDados.TipoBanco.Sql:
                            parametro = new SqlParameter()
                            {
                                ParameterName = nome,
                                DbType = (DbType)tipo,
                                Value = (valor ?? DBNull.Value),
                                Direction = (ParameterDirection)direcao
                            };
                            break;
                        //case Enumeradores.TipoBanco.Oracle:
                        //    parametro = new Oracle.DataAccess.Client.OracleParameter()
                        //    {
                        //        ParameterName = nome,
                        //        OracleDbType = (OracleDbType)tipo,
                        //        Value = (valor ?? DBNull.Value),
                        //        Direction = (ParameterDirection)direcao
                        //    };
                        //    break;
                    }
                }

                if (parametro != null && !string.IsNullOrEmpty(parametro.ParameterName)) 
                {
                    LstParametros.Add(parametro);
                }
            }
            catch (Exception ex)
            {
                throw ex;   
            }
            finally
            {
                parametro = null;
                nome = null;
                valor = null;
                direcao = null;
                tipo = null;

            }
        }

        public static void LimparComando()
        {
            _procedure = null;
            if (_sbQuery != null)
            {
                _sbQuery.Clear();
            }

            if (_dr != null && !_dr.IsClosed)
            {
                _dr.Close();
                _dr.Dispose();
            }

            if (_comando != null)
                _comando.Dispose();

            _lstParametros.Clear();
        }

        public static void Dispose()
        {
            if (_sbQuery != null)
            {
                _sbQuery.Clear();
            }

            if (_dr != null && !_dr.IsClosed)
            {
                _dr.Close();
                _dr.Dispose();
            }

            if (_comando != null)
                _comando.Dispose();

            if (_conexao.State != ConnectionState.Closed)
            {
                _conexao.Close();
                _conexao.Dispose();
            }

            if (_dr != null && !_dr.IsClosed)
            {
                _dr.Close();
                _dr.Dispose();
            }

            if (_comando != null)
                _comando.Dispose();

            if (_conexao.State != ConnectionState.Closed)
            {
                _conexao.Close();
                _conexao.Dispose();
            }

            _lstParametros.Clear();
            ConexaoBanco = null;
            _comando = null;
            _conexao = null;
            _dr = null;
            TipoComando = Enumerators.BancoDados.TipoComando.NaoInformado;
            TipoBanco = Enumerators.BancoDados.TipoBanco.NaoInformado;            
        }

    }
}
