using System;
using System.Configuration;
using FWS.Helper.Cryptography;
using FWS.Helper.Entities;
using FWS.Helper.Enumerators;


namespace FWS.Helper.Configuration
{
    public class Config
    {
        public static eConexaoBanco ObterDadosBanco(BancoDados.BancoConexao bancoAtual)
        {
            var conexaoBanco = new eConexaoBanco();

            if ((int) bancoAtual <= 0) return conexaoBanco;

            if (bancoAtual.Equals(BancoDados.BancoConexao.Fws))
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Banco:Fws:Tipo"]))
                {
                    conexaoBanco.TipoBanco =
                        (BancoDados.TipoBanco)int.Parse(Criptografia.Descriptografar(ConfigurationManager.AppSettings["Banco:Fws:Tipo"]));
                }

                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Banco:Fws:Instancia"]))
                {
                    conexaoBanco.Instancia = Criptografia.Descriptografar(ConfigurationManager.AppSettings["Banco:Fws:Instancia"]);
                }


                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Banco:Fws:Attached"]))
                {
                    var caminho = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
                    conexaoBanco.Attached = caminho + "\\" + Criptografia.Descriptografar(ConfigurationManager.AppSettings["Banco:Fws:Attached"]);
                }


                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Banco:Fws:Banco"]))
                {
                    conexaoBanco.Banco = Criptografia.Descriptografar(ConfigurationManager.AppSettings["Banco:Fws:Banco"]);
                }

                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Banco:Fws:Usuario"]))
                {
                    conexaoBanco.Usuario = Criptografia.Descriptografar(ConfigurationManager.AppSettings["Banco:Fws:Usuario"]);
                }

                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Banco:Fws:Senha"]))
                {
                    conexaoBanco.Senha = Criptografia.Descriptografar(ConfigurationManager.AppSettings["Banco:Fws:Senha"]);
                }
            }
            return conexaoBanco;
        }
    }
}
