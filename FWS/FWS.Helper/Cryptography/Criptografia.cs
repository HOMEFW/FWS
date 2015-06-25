using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using FWS.Helper.Exceptions;

namespace FWS.Helper.Cryptography
{
    public static class Criptografia
    {
        private const string Chave = @"$|N98|*|A14|¨|F81|#|W77|@|C07|$";

        private static TripleDESCryptoServiceProvider _criptografiaTripleDes;
        public static TripleDESCryptoServiceProvider CriptografiaTripleDes
        {
            get
            {
                try
                {
                    if (_criptografiaTripleDes == null)
                    {
                        _criptografiaTripleDes = new TripleDESCryptoServiceProvider
                        {
                            Key = CalcularChaveMd5(Chave),
                            Mode = CipherMode.ECB
                        };
                    }
                }
                catch (Exception ex)
                {
                    _criptografiaTripleDes = null;
                    throw new ApplicationException(Excecao.TratarMensagem(ex));
                }

                return _criptografiaTripleDes;
            }
            set { _criptografiaTripleDes = value; }
        }

        private static MD5CryptoServiceProvider _criptocriptografiaMd5;
        public static MD5CryptoServiceProvider CriptocriptografiaMd5
        {
            get
            {
                if (_criptocriptografiaMd5 == null)
                {
                    _criptocriptografiaMd5 = new MD5CryptoServiceProvider();
                }
                return _criptocriptografiaMd5;
            }
            set { _criptocriptografiaMd5 = value; }
        }

        /// <summary>
        /// Metodo usado para calcular os bytes da chave de seguranca da criptografia
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        private static byte[] CalcularChaveMd5(string valor)
        {
            byte[] calculo = null;
            byte[] arrayBites = null;

            try
            {
                arrayBites = ASCIIEncoding.ASCII.GetBytes(valor);

                if (arrayBites != null)
                {
                    if (arrayBites.Count() > 0)
                    {
                        calculo = CriptocriptografiaMd5.ComputeHash(arrayBites);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new ApplicationException(Excecao.TratarMensagem(ex));
            }
            finally
            {
                arrayBites = null;
                valor = null;
            }

            return calculo;
        }

        public static string Criptografar(string texto)
        {
            string textoCriptografado = null;
            byte[] buffer = null;

            try
            {
                if (!string.IsNullOrEmpty(texto))
                {
                    buffer = ASCIIEncoding.ASCII.GetBytes(texto);
                    textoCriptografado = Convert.ToBase64String(CriptografiaTripleDes.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CriptocriptografiaMd5 = null;
                CriptografiaTripleDes = null;
                buffer = null;
                texto = null;
            }

            return textoCriptografado;
        }

        public static string Descriptografar(string texto)
        {
            string textoDescriptografado = null;
            byte[] buffer = null;

            try
            {
                if (!string.IsNullOrEmpty(texto))
                {
                    buffer = Convert.FromBase64String(texto);
                    textoDescriptografado = ASCIIEncoding.ASCII.GetString(CriptografiaTripleDes.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(Excecao.TratarMensagem(ex));
            }
            finally
            {
                CriptocriptografiaMd5 = null;
                CriptografiaTripleDes = null;
                buffer = null;
                texto = null;
            }
            return textoDescriptografado;
        }
    }
}
