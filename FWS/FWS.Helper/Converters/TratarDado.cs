using System;
using System.Globalization;

namespace FWS.Helper.Converters
{
    public static class TratarDado
    {
        public static DateTime? RetornarData(string data, bool retornarNulo, string formato = "dd/MM/yyyy")
        {
            DateTime? dataEncontrada = null;
            DateTime dataTratada;
            var ci = new CultureInfo("pt-br");

            try
            {
                DateTime.TryParseExact(data, formato, ci, DateTimeStyles.AssumeLocal, out dataTratada);
            }
            catch
            {
                dataTratada = DateTime.MinValue;
            }

            if (dataTratada > DateTime.MinValue)
            {
                dataEncontrada = dataTratada;
            }
            else if (!retornarNulo)
            {
                dataEncontrada = DateTime.MinValue;
            }

            return dataEncontrada;
        }

        public static DateTime? RetornarData(DateTime? data, bool retornarNulo)
        {
            DateTime? dataEncontrada = null;

            if (data.HasValue && data.Value > DateTime.MinValue) 
            {
                dataEncontrada = data;
            }
            else if (!retornarNulo)
            {
                dataEncontrada = DateTime.MinValue;
            }

            return dataEncontrada;
        }

        public static int? RetornaInteiro(string inteiro, bool retornarNulo)
        {
            int? valorEncontrado = null;
            int auxiliar = 0;

            if (int.TryParse(inteiro, out auxiliar) && auxiliar > 0)
            {
                valorEncontrado = auxiliar;
            }
            else if (!retornarNulo)
            {
                valorEncontrado = 0;
            }

            return valorEncontrado;
        }

        public static int? RetornaInteiro(int? inteiro, bool retornarNulo)
        {
            int? valorEncontrado = null;

            if (inteiro.HasValue && inteiro.Value > 0)
            {
                valorEncontrado = inteiro;
            }
            else if (!retornarNulo)
            {
                valorEncontrado = 0;
            }

            return valorEncontrado;
        }

        public static decimal? RetornaDecimal(string valor, bool retornarNulo)
        {
            decimal? valorEncontrado = null;
            decimal auxiliar = 0;

            if (decimal.TryParse(valor, out auxiliar) && auxiliar > 0)
            {
                valorEncontrado = auxiliar;
            }
            else if (!retornarNulo)
            {
                valorEncontrado = 0;
            }

            return valorEncontrado;
        }

        public static decimal? RetornaDecimal(decimal? valor, bool retornarNulo)
        {
            decimal? valorEncontrado = null;

            if (valor.HasValue && valor.Value > 0)
            {
                valorEncontrado = valor;
            }
            else if (!retornarNulo)
            {
                valorEncontrado = 0;
            }

            return valorEncontrado;
        }

        public static string RetornarTexto(string texto, bool retornarNulo, bool indicaCampoEmail = false, bool indicaCampoAlias = false) 
        {
            string textoTratado = null;

            textoTratado = Texto.TransformarParaMaiusculo(Texto.RemoverCaracteresEspeciais(Texto.RemoverDuploEspacamento(texto), indicaCampoEmail, indicaCampoAlias));

            if (!retornarNulo && string.IsNullOrEmpty(textoTratado)) 
            {
                textoTratado = "";
            }

            return textoTratado;
        }

        public static long? RetornaLong(string valor, bool retornarNulo)
        {
            long? valorEncontrado = null;
            long auxiliar = 0;

            if (long.TryParse(valor, out auxiliar) && auxiliar > 0)
            {
                valorEncontrado = auxiliar;
            }
            else if (!retornarNulo)
            {
                valorEncontrado = 0;
            }

            return valorEncontrado;
        }

        public static long? RetornaLong(long? valor, bool retornarNulo)
        {
            long? valorEncontrado = null;

            if (valor.HasValue && valor.Value > 0)
            {
                valorEncontrado = valor;
            }
            else if (!retornarNulo)
            {
                valorEncontrado = 0;
            }

            return valorEncontrado;
        }

        public static string RetornarFlag(string texto, bool retornarNulo)
        {
            string textoTratado = null;

            textoTratado = texto.ToUpper();

            if (!textoTratado.Equals("S") && !textoTratado.Equals("N")) 
            {
                textoTratado = null;
            }

            if (!retornarNulo && string.IsNullOrEmpty(textoTratado))
            {
                textoTratado = "";
            }

            return textoTratado;
        }
    }
}
