using System.Configuration;
using FWS.Helper.Cryptography;
using FWS.Helper.Entities;


namespace FWS.Helper.Configuration
{
    public class Config
    {
        public static eConexaoBanco ObterDadosBanco(Enumerators.BancoDados.BancoConexao bancoAtual)
        {
            var conexaoBanco = new eConexaoBanco();

            if ((int) bancoAtual <= 0) return conexaoBanco;

            if (bancoAtual.Equals(Enumerators.BancoDados.BancoConexao.Fws))
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Banco:Fws:Instancia"]))
                {
                    conexaoBanco.Instancia = Criptografia.Descriptografar(ConfigurationManager.AppSettings["Banco:Fws:Instancia"]);
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
            else if (bancoAtual.Equals(Enumerators.BancoDados.BancoConexao.OracleGcc))
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Banco:GCC:Instancia"]))
                {
                    conexaoBanco.Instancia = Criptografia.Descriptografar(ConfigurationManager.AppSettings["Banco:GCC:Instancia"]);
                }

                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Banco:GCC:Usuario"]))
                {
                    conexaoBanco.Usuario = Criptografia.Descriptografar(ConfigurationManager.AppSettings["Banco:GCC:Usuario"]);
                }

                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Banco:GCC:Senha"]))
                {
                    conexaoBanco.Senha = Criptografia.Descriptografar(ConfigurationManager.AppSettings["Banco:GCC:Senha"]);
                }
            }
            else if (bancoAtual.Equals(Enumerators.BancoDados.BancoConexao.SqlDbCartoes))
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Banco:DbCartoes:Instancia"]))
                {
                    conexaoBanco.Instancia = Criptografia.Descriptografar(ConfigurationManager.AppSettings["Banco:DbCartoes:Instancia"]);
                }

                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Banco:DbCartoes:Banco"]))
                {
                    conexaoBanco.Banco = Criptografia.Descriptografar(ConfigurationManager.AppSettings["Banco:DbCartoes:Banco"]);
                }

                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Banco:DbCartoes:Usuario"]))
                {
                    conexaoBanco.Usuario = Criptografia.Descriptografar(ConfigurationManager.AppSettings["Banco:DbCartoes:Usuario"]);
                }

                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Banco:DbCartoes:Senha"]))
                {
                    conexaoBanco.Senha = Criptografia.Descriptografar(ConfigurationManager.AppSettings["Banco:DbCartoes:Senha"]);
                }
            }
            else if (bancoAtual.Equals(Enumerators.BancoDados.BancoConexao.SqlPreAnalise))
            {
                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Banco:PreAnalise:Instancia"]))
                {
                    conexaoBanco.Instancia = Criptografia.Descriptografar(ConfigurationManager.AppSettings["Banco:PreAnalise:Instancia"]);
                }

                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Banco:PreAnalise:Banco"]))
                {
                    conexaoBanco.Banco = Criptografia.Descriptografar(ConfigurationManager.AppSettings["Banco:PreAnalise:Banco"]);
                }

                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Banco:PreAnalise:Usuario"]))
                {
                    conexaoBanco.Usuario = Criptografia.Descriptografar(ConfigurationManager.AppSettings["Banco:PreAnalise:Usuario"]);
                }

                if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["Banco:PreAnalise:Senha"]))
                {
                    conexaoBanco.Senha = Criptografia.Descriptografar(ConfigurationManager.AppSettings["Banco:PreAnalise:Senha"]);
                }
            }

            return conexaoBanco;
        }
    }
}
