using System;
using System.Text;
using FWS.Helper.Converters;
using FWS.Helper.Entities;
using FWS.Helper.Exceptions;

namespace FWS.Helper.Functions
{
    public static class Comparar
    {
        public static eRetorno Datas(string dataInicial, string nomeDataInicial, string dataFinal, string nomeDataFinal, bool compararDiferencaDias, int? intervalo)
        {
            eRetorno retorno;
            DateTime? inicial = null;
            DateTime? final = null;

            try
            {
                var retornarData = TratarDado.RetornarData(dataInicial, false);
                if (retornarData != null)
                    inicial = retornarData.Value;

                var dateTime = TratarDado.RetornarData(dataFinal, false);
                if (dateTime != null)
                    final = dateTime.Value;

                retorno = Datas(inicial, nomeDataInicial, final, nomeDataFinal, compararDiferencaDias, intervalo);
            }
            catch (Exception ex)
            {
                retorno = Excecao.TratarRetorno(ex);
            }
            finally
            {
                dataInicial = null;
                nomeDataInicial = null;
                dataFinal = null;
                nomeDataFinal = null;
                intervalo = null;
                inicial = null;
                final = null;
            }

            return retorno;
        }

        public static eRetorno Datas(DateTime? dataInicial, string nomeDataInicial, DateTime? dataFinal, string nomeDataFinal, bool compararDiferencaDias, int? intervalo)
        {
            eRetorno retorno = new eRetorno();
            eRetorno retornoInicial = null;
            eRetorno retornoFinal = null;
            StringBuilder sbErro = new StringBuilder();
            int intervaloEmDias = 0;
            DateTime dataComIntervaloDeDias = DateTime.MinValue;

            try
            {
                retornoInicial = Validar.Datas(dataInicial, nomeDataInicial);
                retornoFinal = Validar.Datas(dataFinal, nomeDataFinal);

                if (retornoInicial.OperacaoRealizadaComSucesso && retornoFinal.OperacaoRealizadaComSucesso)
                {
                    if (dataInicial.Value > dataFinal.Value)
                    {
                        sbErro.AppendFormat(";A data {1} não pode ser maior que a data {0}"
                                            , nomeDataInicial
                                            , nomeDataFinal);
                    }                    

                    if (string.IsNullOrEmpty(sbErro.ToString()) && compararDiferencaDias)
                    {
                        intervaloEmDias = intervalo.GetValueOrDefault();

                        if (intervaloEmDias > 0)
                        {
                            dataComIntervaloDeDias = dataInicial.Value.AddDays(intervaloEmDias);

                            if (dataFinal.Value > dataComIntervaloDeDias) 
                            {
                                sbErro.AppendFormat(";A data {0} não pode ser {1} dias maior que a data {2}"
                                            , nomeDataFinal
                                            , intervaloEmDias
                                            , nomeDataInicial);
                            }                               
                        }
                        else
                        {
                            sbErro.Append(";Informe a qual a diferença maxima de dias entre as datas");
                        }
                    }                    
                }
                else
                {
                    if (!retornoInicial.OperacaoRealizadaComSucesso)
                    {
                        sbErro.AppendFormat(";{0}", retornoInicial.MensagemErro);
                    }

                    if (!retornoFinal.OperacaoRealizadaComSucesso)
                    {
                        sbErro.AppendFormat(";{0}", retornoFinal.MensagemErro);
                    }
                }


                if (string.IsNullOrEmpty(sbErro.ToString()))
                {
                    retorno.OperacaoRealizadaComSucesso = true;
                }
                else
                {
                    retorno.OperacaoRealizadaComSucesso = false;
                    retorno.MensagemErro = sbErro.ToString();
                }
            }
            catch (Exception ex)
            {
                retorno = Excecao.TratarRetorno(ex);
            }
            finally
            {
                dataInicial = null;
                nomeDataInicial = null;
                dataFinal = null;
                nomeDataFinal = null;
                intervalo = null;
                retornoInicial = null;
                retornoFinal = null;
                sbErro = null;
            }

            return retorno;
        }

    }
}
