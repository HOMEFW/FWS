using System;

namespace FWS.Helper.Entities
{
    [Serializable]
    public class eConexaoBanco
    {
        public string ConexaoOracle
        {
            get
            {
                return string.Format(@"Data Source={0};User Id={1};Password={2}"
                                            , Instancia
                                            , Usuario
                                            , Senha);
            }
        }

        public string ConexaoSql
        {
            get
            {
                return string.Format(@"Data Source={0};Initial Catalog={1};User Id={2};Password={3}"
                                            , Instancia
                                            , Banco
                                            , Usuario
                                            , Senha);


            }
        }

        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Banco { get; set; }
        public string Instancia { get; set; }
    }
}
