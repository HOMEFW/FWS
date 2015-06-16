using System;
using FWS.Helper.Exceptions;

namespace FWS.Helper.Functions
{
    public static class Calcula
    {
        public static int? Modulo11(string texto)
        {
            int? valor = null;
            int calculo = 0;
            int valorCalculo = 0;
            int item = 0;

            try
            {
                for (int textoItem = 0; textoItem < texto.Length; textoItem++)
                {
                    if (int.TryParse(texto[textoItem].ToString(), out item))
                    {
                        calculo = calculo + (item * (texto.Length + 1 - textoItem));//TODO VERIFICAR
                    }
                }

                valorCalculo = 11 - (calculo % 11);

                if (valorCalculo == 10 || valorCalculo == 11)
                {
                    valorCalculo = 0;
                }

                valor = valorCalculo;

            }
            catch (Exception ex)
            {
                valor = null;
                throw new ApplicationException(Excecao.TratarMensagem(ex));
            }
            finally
            {
                texto = null;
                calculo = 0;
                valorCalculo = 0;
                item = 0;
            }

            return valor;
        }

        public static int? DigitoCnpj(string texto)
        {
            int? valor = null;
            int calculo = 0;
            int item = 0;
            int quociente = 0;

            try
            {
                quociente = texto.Length - 7;

                for (int textoItem = 0; textoItem < texto.Length; textoItem++)
                {
                    if (int.TryParse(texto[textoItem].ToString(), out item))
                    {
                        calculo = calculo + (item * quociente--);

                        if (quociente < 2)
                        {
                            quociente = 9;
                        }
                    }
                }

                valor = (calculo % 11) < 2 ? 0 : (11 - (calculo % 11));
            }
            catch (Exception ex)
            {
                valor = null;
                throw new ApplicationException(Excecao.TratarMensagem(ex));
            }
            finally
            {
                texto = null;
                item = 0;
                calculo = 0;
                quociente = 0;
            }

            return valor;
        }

        public static int Idade(DateTime data)
        {
            int idade = 0;
            TimeSpan ts = DateTime.Today - data;
            DateTime idadeCalculada = (new DateTime() + ts).AddYears(-1).AddDays(-1);
            idade = idadeCalculada.Year;
            return idade;
        }

    }
}
