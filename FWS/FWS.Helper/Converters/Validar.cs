using System;
using System.Linq;
using System.Text;
using FWS.Dictionary;
using FWS.Helper.Entities;
using FWS.Helper.Enumerators;
using FWS.Helper.Functions;

namespace FWS.Helper.Converters
{
    public static class Validar
    {
        public static eRetorno Datas(DateTime? data, string nomeData)
        {
            var retorno = new eRetorno();

            if (!data.HasValue)
            {
                retorno.MensagemErro = string.Format("Informe a data {0}", nomeData);
            }
            else if (data.Value <= DateTime.MinValue || data.Value >= DateTime.MaxValue)
            {
                retorno.MensagemErro = string.Format("Informe uma data {0} valida", nomeData);
            }

            if (string.IsNullOrEmpty(retorno.MensagemErro))
            {
                retorno.OperacaoRealizadaComSucesso = true;
            }

            return retorno;
        }

        public static eRetorno ValidarDocumento(Enumeradores.Documento tipoDocumento, string documento)
        {
            bool documentoValido = false;
            string mensagemErro = null;
            var retorno = new eRetorno();

            try
            {
                switch (tipoDocumento)
                {
                    case Enumeradores.Documento.CPF:
                        documentoValido = ValidarCpf(documento, ref mensagemErro);
                        break;
                    case Enumeradores.Documento.RG:
                        documentoValido = ValidarRg(documento, ref mensagemErro);
                        break;
                    case Enumeradores.Documento.CNPJ:
                        documentoValido = ValidarCnpj(documento, ref mensagemErro);
                        break;
                    case Enumeradores.Documento.CNH:
                        documentoValido = ValidarCnh(documento, ref mensagemErro);
                        break;
                    default:
                        documentoValido = false;
                        mensagemErro = "Documento inválido";
                        break;
                }

                if (documentoValido)
                {
                    retorno.OperacaoRealizadaComSucesso = true;
                }
                else
                {
                    retorno.MensagemErro = mensagemErro;
                }
            }
            catch (Exception ex)
            {
                retorno.MensagemErro = ex.Message;
                retorno.OcorreuExcessao = true;
            }
            finally
            {
                mensagemErro = null;
                documento = null;
            }

            return retorno;
        }

        public static eRetorno ValidarEmail(string email)
        {
            var retorno = new eRetorno();

            try
            {
                if (!string.IsNullOrEmpty(email))
                {
                    if (ExpressoesRegulares.RgxEmail.IsMatch(email))
                    {
                        retorno.OperacaoRealizadaComSucesso = true;
                    }
                    else
                    {
                        retorno.MensagemErro = Mensages.EmailInvalido;
                    }
                }
                else
                {
                    retorno.MensagemErro = Mensages.InformeEmail;
                }
            }
            catch (Exception ex)
            {
                retorno.MensagemErro = ex.Message;
                retorno.OcorreuExcessao = true;
                ExpressoesRegulares.RgxEmail = null;
            }
            finally
            {
                email = null;
            }

            return retorno;
        }


        public static eRetorno NomeCompleto(string texto)
        {
            var retorno = new eRetorno();
            string[] textoSeparado = null;

            if (!string.IsNullOrEmpty(texto))
            {
                texto = Texto.RemoverDuploEspacamento(texto);

                if (!string.IsNullOrEmpty(texto))
                {
                    textoSeparado = texto.Split(' ').Where(q => !string.IsNullOrEmpty(q)).ToArray();

                    if (textoSeparado.Length > 1)
                    {
                        retorno.OperacaoRealizadaComSucesso = true;                        
                    }
                    else
                    {
                        retorno.OperacaoRealizadaComSucesso = false;
                        retorno.MensagemErro = Mensages.InformeNome;
                    }
                }
                else
                {
                    retorno.OperacaoRealizadaComSucesso = false;
                    retorno.MensagemErro = Mensages.InformeNome;
                }
            }
            else
            {
                retorno.OperacaoRealizadaComSucesso = false;
                retorno.MensagemErro = Mensages.InformeNome;
            }

            return retorno;
        }

        public static eRetorno Telefone(string telefone)
        {
            var retorno = new eRetorno();

            if (!string.IsNullOrEmpty(telefone))
            {
                if (!ExpressoesRegulares.RgxTelefone.IsMatch(telefone))
                {
                    retorno.OperacaoRealizadaComSucesso = true;
                }
                else
                {
                    retorno.OperacaoRealizadaComSucesso = false;
                    retorno.MensagemErro = Mensages.InformeTelefoneValido;
                }
            }
            else
            {
                retorno.OperacaoRealizadaComSucesso = false;
                retorno.MensagemErro = Mensages.InformeTelefone;
            }

            return retorno;
        }

        private static eRetorno Cep(string cep)
        {
            var retorno = new eRetorno();

            var sbErro = new StringBuilder();
            var value = "";
            long cepTratado = 0;

            if (!string.IsNullOrEmpty(cep))
            {
                value = cep.Replace("-", "");

                if (value.Length == 8 && long.TryParse(value.Substring(0, 2), out cepTratado) && cepTratado > 0)
                {
                    for (var iCont = 0; iCont < (value.Length - 1); iCont++)
                    {
                        if (value.Substring(iCont, 1) != value.Substring(iCont + 1, 1))
                            retorno.OperacaoRealizadaComSucesso = true; //achou um diferente
                    }

                    if (!retorno.OperacaoRealizadaComSucesso)
                    {
                        retorno.MensagemErro = Mensages.InformeCepValido;
                    }
                }
                else
                {
                    retorno.MensagemErro = Mensages.InformeCepValido;
                    retorno.OperacaoRealizadaComSucesso = false;
                }
            }
            else
            {
                retorno.MensagemErro = Mensages.InformeCep;
                retorno.OperacaoRealizadaComSucesso = false;
            }


            return retorno;
        }

        public static eRetorno CepPorUf(string cep, string uf)
        {
            var retorno = new eRetorno();
            var sbErro = new StringBuilder();            
            bool valido = true;
            long cepTratado = 0;


            retorno = Cep(cep);

            if (!retorno.OperacaoRealizadaComSucesso) 
            {
                sbErro.AppendFormat("|{0}", retorno.MensagemErro);
            }

            if (string.IsNullOrEmpty(uf))
            {
                sbErro.AppendFormat("|{0}", "Informe a UF");
            }

            if (string.IsNullOrEmpty(sbErro.ToString()))
            {
                long.TryParse(cep.Replace("-", ""), out cepTratado);
                switch (uf.ToUpper())
                {
                    case "AC": if (cepTratado < 69900000 || cepTratado > 69999999) { valido = false; } break;
                    case "AL": if (cepTratado < 57000000 || cepTratado > 57999999) { valido = false; } break;
                    case "AM":
                        {
                            if ((cepTratado >= 69000000 && cepTratado <= 69299999) || (cepTratado >= 69400000 && cepTratado <= 69899999))
                            {
                                valido = true;
                            }
                            else
                            {
                                valido = false;
                            }
                        }
                        break;
                    case "AP": if (cepTratado < 68900000 || cepTratado > 68999999) { valido = false; } break;
                    case "BA": if (cepTratado < 40000000 || cepTratado > 48999999) { valido = false; } break;
                    case "CE": if (cepTratado < 60000000 || cepTratado > 63999999) { valido = false; } break;
                    case "DF":
                        {
                            if ((cepTratado >= 70000000 && cepTratado <= 72799999) || (cepTratado >= 73000000 && cepTratado <= 73699999))
                            {
                                valido = true;
                            }
                            else
                            {
                                valido = false;
                            }
                        }
                        break;
                    case "ES": if (cepTratado < 29000000 || cepTratado > 29999999) { valido = false; } break;
                    case "GO":
                        {
                            if ((cepTratado >= 72800000 && cepTratado <= 72999999) || (cepTratado >= 73700000 && cepTratado <= 76799999))
                            {
                                valido = true;
                            }
                            else
                            {
                                valido = false;
                            }
                        }
                        break;
                    case "MA": if (cepTratado < 65000000 || cepTratado > 65999999) { valido = false; } break;
                    case "MG": if (cepTratado < 30000000 || cepTratado > 39999999) { valido = false; } break;
                    case "MS": if (cepTratado < 79000000 || cepTratado > 79999999) { valido = false; } break;
                    case "MT": if (cepTratado < 78000000 || cepTratado > 78899999) { valido = false; } break;
                    case "PA": if (cepTratado < 66000000 || cepTratado > 68899999) { valido = false; } break;
                    case "PB": if (cepTratado < 58000000 || cepTratado > 58999999) { valido = false; } break;
                    case "PE": if (cepTratado < 50000000 || cepTratado > 56999999) { valido = false; } break;
                    case "PI": if (cepTratado < 64000000 || cepTratado > 64999999) { valido = false; } break;
                    case "PR": if (cepTratado < 80000000 || cepTratado > 87999999) { valido = false; } break;
                    case "RJ": if (cepTratado < 20000000 || cepTratado > 28999999) { valido = false; } break;
                    case "RN": if (cepTratado < 59000000 || cepTratado > 59999999) { valido = false; } break;
                    case "RO": if (cepTratado < 76800000 || cepTratado > 76999999) { valido = false; } break;
                    case "RR": if (cepTratado < 69300000 || cepTratado > 69399999) { valido = false; } break;
                    case "RS": if (cepTratado < 90000000 || cepTratado > 99999999) { valido = false; } break;
                    case "SC": if (cepTratado < 88000000 || cepTratado > 89999999) { valido = false; } break;
                    case "SE": if (cepTratado < 49000000 || cepTratado > 49999999) { valido = false; } break;
                    case "SP": if (cepTratado < 01000000 || cepTratado > 19999999) { valido = false; } break;
                    case "TO": if (cepTratado < 77000000 || cepTratado > 77999999) { valido = false; } break;
                    default: valido = false; break;
                }

                if (!valido)
                {
                    sbErro.AppendFormat("|{0}", "Cep não pertence a UF informada");
                }
            }

            if (string.IsNullOrEmpty(sbErro.ToString()))
            {
                retorno.OperacaoRealizadaComSucesso = true;
            }
            else
            {
                retorno.OperacaoRealizadaComSucesso = false;
                retorno.MensagemErro = sbErro.ToString().Substring(1);
            }

            return retorno;
        }

        #region metodos de apoio
        private static bool ValidarCpf(string cpf, ref string mensagemErro)
        {
            bool cpfValido = false;
            int primeiroDigitoCalculado = 0;
            int segundoDigitoCalculado = 0;
            int primeiroDigitoInformado = 0;
            int segundoDigitoInformado = 0;
            int? calculo = null;

            try
            {
                if (ExpressoesRegulares.RgxCpf.IsMatch(cpf))
                {
                    cpf = Texto.RemoverCaracteresEspeciais(cpf);

                    if (!string.IsNullOrEmpty(cpf))
                    {
                        if (cpf.Length == 11)
                        {

                            if (cpf != "00000000000"
                                && cpf != "11111111111"
                                && cpf != "22222222222"
                                && cpf != "33333333333"
                                && cpf != "44444444444"
                                && cpf != "55555555555"
                                && cpf != "66666666666"
                                && cpf != "77777777777"
                                && cpf != "88888888888"
                                && cpf != "99999999999")
                            {
                                if (int.TryParse(cpf[cpf.Length - 1].ToString(), out segundoDigitoInformado)
                                    && int.TryParse(cpf[cpf.Length - 2].ToString(), out primeiroDigitoInformado))
                                {
                                    calculo = Calcula.Modulo11(cpf.Substring(0, cpf.Length - 2));

                                    if (calculo != null)
                                    {
                                        if (int.TryParse(calculo.ToString(), out primeiroDigitoCalculado))
                                        {
                                            calculo = null;

                                            if (primeiroDigitoCalculado.Equals(primeiroDigitoInformado))
                                            {
                                                calculo = Calcula.Modulo11(cpf.Substring(0, cpf.Length - 1));

                                                if (int.TryParse(calculo.ToString(), out segundoDigitoCalculado))
                                                {
                                                    calculo = null;

                                                    if (segundoDigitoCalculado.Equals(segundoDigitoInformado))
                                                    {
                                                        cpfValido = true;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        if (!cpfValido)
                        {
                            mensagemErro = Mensages.CPFInvalido;
                        }
                    }
                    else
                    {
                        mensagemErro = Mensages.InformeCPF;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(cpf))
                    {
                        mensagemErro = Mensages.InformeCPF;
                    }
                    else
                    {
                        mensagemErro = Mensages.CPFInvalido;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cpf = null;
                ExpressoesRegulares.RgxCpf = null;
                primeiroDigitoCalculado = 0;
                segundoDigitoCalculado = 0;
                primeiroDigitoInformado = 0;
                segundoDigitoInformado = 0;
                calculo = null;
            }

            return cpfValido;
        }

        private static bool ValidarCnpj(string cnpj, ref string mensgemErro)
        {
            bool cnpjValido = false;
            int primeiroDigitoInformado = 0;
            int primeiroDigitoCalculado = 0;
            int segundoDigitoInformado = 0;
            int segundoDigitoCalculado = 0;
            int? valor = null;

            try
            {
                cnpj = Texto.RemoverCaracteresEspeciais(cnpj);

                if (!string.IsNullOrEmpty(cnpj))
                {
                    if (ExpressoesRegulares.RgxCnpj.IsMatch(cnpj))
                    {
                        if (cnpj.Length == 14)
                        {
                            if (cnpj != "00000000000000"
                                && cnpj != "11111111111111"
                                && cnpj != "22222222222222"
                                && cnpj != "33333333333333"
                                && cnpj != "44444444444444"
                                && cnpj != "55555555555555"
                                && cnpj != "66666666666666"
                                && cnpj != "77777777777777"
                                && cnpj != "88888888888888"
                                && cnpj != "99999999999999")
                            {
                                if (int.TryParse(cnpj.Substring(12, 1), out primeiroDigitoInformado)
                                    && int.TryParse(cnpj.Substring(13, 1), out segundoDigitoInformado))
                                {
                                    valor = Calcula.DigitoCnpj(cnpj.Substring(0, cnpj.Length - 2));

                                    if (int.TryParse(valor.ToString(), out primeiroDigitoCalculado))
                                    {
                                        if (primeiroDigitoCalculado.Equals(primeiroDigitoInformado))
                                        {
                                            valor = Calcula.DigitoCnpj(cnpj.Substring(0, cnpj.Length - 1));

                                            if (int.TryParse(valor.ToString(), out segundoDigitoCalculado))
                                            {
                                                if (segundoDigitoCalculado.Equals(segundoDigitoInformado))
                                                {
                                                    cnpjValido = true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    if (!cnpjValido)
                    {
                        mensgemErro = Mensages.CNPJInvalido;
                    }
                }
                else
                {
                    mensgemErro = Mensages.InformeCNPJ;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnpj = null;
                primeiroDigitoInformado = 0;
                primeiroDigitoCalculado = 0;
                segundoDigitoInformado = 0;
                segundoDigitoCalculado = 0;
                ExpressoesRegulares.RgxCnpj = null;
            }

            return cnpjValido;
        }

        private static bool ValidarRg(string rg, ref string mensagemErro)
        {
            bool rgValido = false;
            double calculo = 0;
            int quociente = 0;
            int valorCalculo = 0;
            int itemRg = 0;

            try
            {
                rg = Texto.RemoverCaracteresEspeciais(rg);

                if (!string.IsNullOrEmpty(rg))
                {
                    if (ExpressoesRegulares.RgxRg.IsMatch(rg))
                    {
                        if (rg.Length == 9 && !ExpressoesRegulares.RgxLetras.IsMatch(rg[rg.Length - 1].ToString()))
                        {
                            quociente = 2;
                            for (int item = 0; item < rg.Length; item++)
                            {
                                if (int.TryParse(rg[item].ToString(), out itemRg))
                                {
                                    valorCalculo = valorCalculo + (itemRg * quociente);

                                    quociente = quociente + 1;
                                    if (quociente > 9)
                                    {
                                        quociente = 100;
                                    }
                                }
                            }

                            calculo = (valorCalculo % 11);

                            if (calculo == 0)
                            {
                                rgValido = true;
                            }
                        }
                        else
                        {
                            // RG SEM DIGITO / OU SEM DIGITO NUMERICO
                            rgValido = true;
                        }
                    }

                    if (!rgValido)
                    {
                        mensagemErro = Mensages.RGInvalido;
                    }
                }
                else
                {
                    mensagemErro = Mensages.InformeRG;
                }
            }
            catch (Exception ex)
            {
                rg = null;
                throw ex;
            }
            finally
            {
                rg = null;
                ExpressoesRegulares.RgxRg = null;
                ExpressoesRegulares.RgxLetras = null;
                calculo = 0;
                quociente = 0;
                valorCalculo = 0;
                itemRg = 0;
            }

            return rgValido;
        }

        private static bool ValidarCnh(string cnh, ref string mensagemErro)
        {
            bool cnhValida = false;
            double calculo = 0;
            int item = 0;
            int valorCalculo = 0;
            int quociente = 0;
            int primeiroDigito = 0;

            try
            {

                cnh = Texto.RemoverCaracteresEspeciais(cnh);

                if (!string.IsNullOrEmpty(cnh))
                {
                    if (ExpressoesRegulares.RgxCnh.IsMatch(cnh))
                    {
                        if (cnh.Length == 9 || cnh.Length == 11)
                        {
                            if (cnh.Length == 9)
                            {
                                if (int.TryParse(cnh.Substring(cnh.Length - 1, 1), out primeiroDigito))
                                {
                                    quociente = 2;
                                    for (int itemCNH = 0; itemCNH < (cnh.Length - 1); itemCNH++)
                                    {
                                        if (int.TryParse(cnh[item].ToString(), out itemCNH))
                                        {
                                            valorCalculo = valorCalculo + (itemCNH * quociente);
                                            quociente = quociente + 1;
                                        }
                                    }

                                    calculo = (valorCalculo % 11);

                                    if (calculo.Equals(primeiroDigito))
                                    {
                                        cnhValida = true;
                                    }
                                }
                            }
                            else if (cnh.Length == 11)
                            {
                                cnhValida = true;
                            }
                        }
                    }

                    if (!cnhValida)
                    {
                        mensagemErro = Mensages.CNHInvalida;
                    }
                }
                else
                {
                    mensagemErro = Mensages.InformeCNH;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnh = null;
                ExpressoesRegulares.RgxCnh = null;
            }

            return cnhValida;
        }

        #endregion metodos de apoio

        //public static eRetorno ValidarArquivo(PAN.HELPERS.ENT.eArquivo arquivo, string descricaoArquivo)
        //{
        //    eRetorno retorno = new eRetorno();
        //    StringBuilder sbErro = new StringBuilder();

        //    try
        //    {

        //        if (arquivo != null)
        //        {
        //            if (string.IsNullOrEmpty(arquivo.DiretorioArquivo))
        //            {
        //                sbErro.AppendFormat("|{0}", DICIONARIO.Erro.InformeArquivoDiretorio);
        //            }

        //            if (string.IsNullOrEmpty(arquivo.Nome))
        //            {
        //                sbErro.AppendFormat("|{0}", DICIONARIO.Erro.InformeArquivoNome);
        //            }

        //            if (string.IsNullOrEmpty(arquivo.Extensao))
        //            {
        //                sbErro.AppendFormat("|{0}", DICIONARIO.Erro.InformeArquivoExtensao);
        //            }

        //            if (string.IsNullOrEmpty(arquivo.CaminhoCompleto))
        //            {
        //                sbErro.AppendFormat("|{0}", DICIONARIO.Erro.InformeArquivoCaminho);
        //            }
        //        }
        //        else
        //        {
        //            sbErro.AppendFormat("|{0}", DICIONARIO.Erro.ObjetoInvalido);
        //        }

        //        if (!string.IsNullOrEmpty(sbErro.ToString()))
        //        {
        //            retorno.OperacaoRealizadaComSucesso = false;
        //            retorno.MensagemErro = string.Format("{0} {1} [{2}]"
        //                                                , DICIONARIO.Texto.OcorreuUmErroNoArquivoDE
        //                                                , descricaoArquivo
        //                                                , sbErro.ToString());
        //        }
        //        else
        //        {
        //            retorno.OperacaoRealizadaComSucesso = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        retorno = Excecao.TratarRetorno(ex);
        //    }
        //    finally
        //    {
        //        arquivo = null;
        //    }

        //    return retorno;
        //}

    }
}
