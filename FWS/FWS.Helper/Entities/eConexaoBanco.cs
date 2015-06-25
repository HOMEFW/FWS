using System;
using System.Data.SqlClient;
using FWS.Helper.Enumerators;

namespace FWS.Helper.Entities
{
    [Serializable]
    public class eConexaoBanco
    {
        public string GetConexao
        {
            get
            {
                switch (TipoBanco)
                {
                    case BancoDados.TipoBanco.Oracle:
                        return string.Format(@"Data Source={0};User Id={1};Password={2}"
                            , Instancia
                            , Usuario
                            , Senha);

                    case BancoDados.TipoBanco.Sql:
                        return string.Format(@"Data Source={0};Initial Catalog={1};User Id={2};Password={3}"
                            , Instancia
                            , Banco
                            , Usuario
                            , Senha);

                    case BancoDados.TipoBanco.SqlLocalDb:
                        return new SqlConnectionStringBuilder()
                        {
                            AttachDBFilename = Attached,
                            DataSource = Instancia,
                            InitialCatalog = Banco,
                            IntegratedSecurity = true
                        }.ToString();
                    default:
                        return null;
                }
            }
        }

        public BancoDados.TipoBanco TipoBanco { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Banco { get; set; }
        public string Instancia { get; set; }
        public string Attached { get; set; }
    }
}
