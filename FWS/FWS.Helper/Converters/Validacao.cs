using System;
using FWS.Dictionary;
using FWS.Helper.Entities;
using FWS.Helper.Enumerators;
using FWS.Helper.Functions;

namespace FWS.Helper.Converters
{
    public static class Validacao
    {
        public static eRetorno ValidarDocumento(Enumeradores.Documento tipoDocumento, string documento)
        {
            var documentoValido = false;
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

        private static bool ValidarCpf(string cpf, ref string mensagemErro)
        {
            var cpfValido = false;
            var primeiroDigitoCalculado = 0;
            var segundoDigitoCalculado = 0;
            var primeiroDigitoInformado = 0;
            var segundoDigitoInformado = 0;
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
                            mensagemErro = Mensages.CNPJInvalido;
                        }
                    }
                    else
                    {
                        mensagemErro = Mensages.InformeCPF;
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
            var cnpjValido = false;
            var primeiroDigitoInformado = 0;
            var primeiroDigitoCalculado = 0;
            var segundoDigitoInformado = 0;
            var segundoDigitoCalculado = 0;
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
            var rgValido = false;
            var calculo = 0;
            var quociente = 0;
            var valorCalculo = 0;
            var itemRg = 0;

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
                            for (var item = 0; item < rg.Length; item++)
                            {
                                if (int.TryParse(item.ToString(), out itemRg))
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
    }
}
