using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using FWS.Helper.Exceptions;

namespace FWS.Helper.Converters
{
    public static class Texto
    {
        #region Propriedades
        private static List<string> _lstCaracteresEspeciais;
        public static List<string> LstCaracteresEspeciais
        {
            get
            {
                if (_lstCaracteresEspeciais == null || _lstCaracteresEspeciais.Count <= 0)
                {
                    _lstCaracteresEspeciais = new List<string>
                    {
                        @"'",
                        "\"",
                        @"'",
                        @"-",
                        @".",
                        @";",
                        @"(",
                        @")",
                        @"*",
                        @"~",
                        @"_",
                        @"/",
                        @"\",
                        @"*",
                        @".",
                        @"/",
                        @"\\",
                        @"(",
                        @")",
                        @"-",
                        @"!",
                        @"#",
                        @"@",
                        @"$",
                        @"%",
                        @"¨",
                        @"&",
                        @"*",
                        @"_",
                        @"=",
                        @"§",
                        @"|",
                        @"<",
                        @">",
                        @":",
                        @";",
                        @"?",
                        @"]",
                        @"}",
                        @"{",
                        @"[",
                        @"`",
                        @"^",
                        @"~",
                        @"º",
                        @"ª",
                        @"°",
                        @"+",
                        @"´",
                        "/\"",
                        @"¿",
                        @"£",
                        @"α",
                        @"ß",
                        @"Γ",
                        @"π",
                        @"Σ",
                        @"σ",
                        @"µ",
                        @"τ",
                        @"Φ",
                        @"Θ",
                        @"Ω",
                        @"δ",
                        @"∞",
                        @"φ",
                        @"ε",
                        @"∩",
                        @"≡",
                        @"±",
                        @"≥",
                        @"≤",
                        @"⌠",
                        @"⌡",
                        @"÷",
                        @"≈",
                        @"≈",
                        @"√",
                        @"ⁿ",
                        @"²",
                        @"■",
                        @"æ",
                        @"Æ",
                        @"¢",
                        @"£",
                        @"¥",
                        @"₧",
                        @"ƒ",
                        @"ª",
                        @"º",
                        @"¿",
                        @"⌐",
                        @"¬",
                        @"½",
                        @"¼",
                        @"«",
                        @"»",
                        @"░",
                        @"▒",
                        @"▓",
                        @"│",
                        @"┤",
                        @"╡",
                        @"╢",
                        @"╖",
                        @"╕",
                        @"╣",
                        @"║",
                        @"╗",
                        @"╝",
                        @"╜",
                        @"╛",
                        @"┐",
                        @"└",
                        @"┴",
                        @"┬",
                        @"├",
                        @"─",
                        @"┼",
                        @"╞",
                        @"╟",
                        @"╚",
                        @"╔",
                        @"╩",
                        @"╦",
                        @"╠",
                        @"═",
                        @"╬",
                        @"╧",
                        @"╨",
                        @"╤",
                        @"╥",
                        @"╙",
                        @"╒",
                        @"╓",
                        @"╫",
                        @"╪",
                        @"┘",
                        @"┌",
                        @"█",
                        @"▄",
                        @"▌",
                        @"▐",
                        @"▀"
                    };
                }

                return _lstCaracteresEspeciais;
            }
            set { _lstCaracteresEspeciais = value; }
        }

        private static List<string> _lstLetrasEspeciais;
        public static List<string> LstLetrasEspeciais
        {
            get
            {
                if (_lstLetrasEspeciais != null && _lstLetrasEspeciais.Count > 0) return _lstLetrasEspeciais;

                _lstLetrasEspeciais = new List<string>
                {
                    @"ç;c",
                    @"Ç;C",
                    @"Ã;A",
                    @"ã;a",
                    @"Õ;O",
                    @"õ;o",
                    @"Â;A",
                    @"â;a",
                    @"ô;o",
                    @"Ô;O",
                    @"Ê;E",
                    @"ê;e",
                    @"Á;A",
                    @"á;a",
                    @"É;E",
                    @"é;e",
                    @"Í;I",
                    @"í;i",
                    @"Ó;O",
                    @"ó;o",
                    @"À;A",
                    @"à;a",
                    @"È;E",
                    @"è;e",
                    @"Ò;O",
                    @"ò;o",
                    @"Ü;U",
                    @"ü;u",
                    @"Ú;U",
                    @"ú;u",
                    @"Ù;U",
                    @"ù;u",
                    @"ä;a",
                    @"å;a",
                    @"ë;e",
                    @"ï;i",
                    @"î;i",
                    @"Ä;A",
                    @"Å;A",
                    @"ö;O",
                    @"û;u",
                    @"ÿ;y",
                    @"Ö;O",
                    @"Ü;U",
                    @"í;i",
                    @"ó;o",
                    @"ñ;n",
                    @"Ñ;N",
                    @"¡;i",
                    @"Ô;O"
                };

                return _lstLetrasEspeciais;
            }
            set { _lstLetrasEspeciais = value; }
        }

        private static List<string> _lstNumeros;
        public static List<string> LstNumeros
        {
            get
            {
                if (_lstNumeros == null)
                {
                    _lstNumeros = new List<string> {@"0", @"1", @"2", @"3", @"4", @"5", @"6", @"7", @"8", @"9"};
                }

                return _lstNumeros;
            }
            set { _lstNumeros = value; }
        }

        #endregion Propriedades

        public static string TransformarParaMaiusculo(string texto)
        {
            return (!string.IsNullOrEmpty(texto) ? texto.ToUpper() : texto);
        }

        public static string RemoverCaracteresEspeciais(string texto, bool campoEmail = false, bool campoAlias = false)
        {
            try
            {
                if (!string.IsNullOrEmpty(texto))
                {
                    if (texto.Length > 0)
                    {
                        foreach (var caractere in LstCaracteresEspeciais)
                        {
                            if (!campoEmail && !campoAlias)
                            {
                                texto = texto.Replace(caractere, string.Empty);
                            }
                            else if (campoEmail && !(caractere == "@" || caractere == "_" || caractere == "-" || caractere == "."))
                            {
                                texto = texto.Replace(caractere, string.Empty);
                            }
                            else if (campoAlias && caractere != "_")
                            {
                                texto = texto.Replace(caractere, string.Empty);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(Excecao.TratarMensagem(ex));
            }
            finally
            {
                LstCaracteresEspeciais = null;
            }

            return texto;
        }

        public static string SubstituirLetrasEspeciais(string texto)
        {
            try
            {
                if (!string.IsNullOrEmpty(texto))
                {
                    if (texto.Length > 0)
                    {
                        foreach (var caractere in LstLetrasEspeciais)
                        {
                            var letrasEspeciais = caractere.Split(';');
                            if (letrasEspeciais.Length > 0)
                            {
                                texto = texto.Replace(letrasEspeciais[0], letrasEspeciais[1]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(Excecao.TratarMensagem(ex));
            }
            finally
            {
                LstLetrasEspeciais = null;
            }

            return texto;
        }

        public static string LerHtml(string caminho)
        {
            string texto = null;
            FileInfo fiCaminho = null;
            StreamReader sr = null;
            try
            {
                if (!string.IsNullOrEmpty(caminho))
                {
                    fiCaminho = new FileInfo(caminho);
                    if (fiCaminho.Exists)
                    {
                        sr = new StreamReader(caminho);
                        texto = sr.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                fiCaminho = null;
                sr = null;
                caminho = null;
            }

            return texto;
        }

        public static string CompactarNome(string strNome, int intMaxCaracteres = 0)
        {
            if (string.IsNullOrEmpty(strNome))
            {
                return "";
            }

            //verifica parâmetro
            if (intMaxCaracteres < 15)
                return strNome;

            //dividir o nome em palavras separadas por espaço
            while (strNome.IndexOf("  ") >= 0)
                strNome = strNome.Replace("  ", " ");

            var strMatrizNome = strNome.Trim().Split(new Char[] { ' ' });

            //percorrer a lista à procura das preposições da primeira até a última palavra do nome
            var intQtdOcc = strMatrizNome.GetUpperBound(0);
            var strRetorno = strMatrizNome[0].ToUpper();
            var regExc = new Regex("DA|DE|DO|DAS|DOS|E");

            for (var i = 1; i < intQtdOcc; i++)
            {
                //quando não for uma preposição juntar ao nome final
                if (!(regExc.Match(strMatrizNome[i].ToUpper()).Success && strMatrizNome[i].Length <= 3))
                {
                    strRetorno += " " + AbreviarParentesco(strMatrizNome[i].ToUpper());
                }
            }
            strRetorno += " " + strMatrizNome[intQtdOcc].ToUpper();

            //quando o tamanho do nome for menor ou igual ao máximo, não abreviar
            if (strRetorno.Length <= intMaxCaracteres)
                return strRetorno;

            //separar novamente e obtem a quantidade total de nomes
            strMatrizNome = strRetorno.Split(new Char[] { ' ' });
            intQtdOcc = strMatrizNome.GetUpperBound(0);
            var strParentesco = strMatrizNome[intQtdOcc];
            var strParentescoAbrev = AbreviarParentesco(strParentesco);

            //Se o nome for menor ou igual a dois itens, abrevia até chegar ao desejado e retorna
            if (intQtdOcc < 2)
            {
                if (intQtdOcc == 1)
                {
                    strRetorno = strMatrizNome[0] + " " + strParentescoAbrev;
                    if (strRetorno.Length > intMaxCaracteres)
                    {
                        strRetorno = strMatrizNome[0].Substring(0, 1) + " " + strParentesco;
                        if (strRetorno.Length > intMaxCaracteres)
                            strRetorno = strMatrizNome[0].Substring(0, 1) + " " + strParentescoAbrev;
                    }
                }

                while (strRetorno.Length > intMaxCaracteres)
                    strRetorno = strRetorno.Substring(0, strRetorno.Length - 1);

                return strRetorno;
            }

            //Abrevia os nomes até chegar ao corte desejado 
            var strMatrizNomeBase = strRetorno.Split(new Char[] { ' ' });
            if (strRetorno.Length > intMaxCaracteres)
            {
                strMatrizNome[intQtdOcc] = strParentescoAbrev;
                for (var i = 1; i < intQtdOcc; i++)
                {
                    strRetorno = JuntarNomes(strMatrizNome);
                    if (strRetorno.Length <= intMaxCaracteres)
                        break;

                    strMatrizNome[i] = strMatrizNome[i].Substring(0, 1);
                    if (i <= 1) continue;
                    strRetorno = JuntarNomes(strMatrizNome);
                    if (strRetorno.Length > intMaxCaracteres) continue;

                    for (var y = 1; y < intQtdOcc; y++)
                    {
                        strMatrizNome[y] = strMatrizNomeBase[y];
                        strRetorno = JuntarNomes(strMatrizNome);
                        if (strRetorno.Length <= intMaxCaracteres)
                            break;
                        else
                        {
                            strMatrizNome[y] = strMatrizNome[y].Substring(0, 1);
                            strRetorno = JuntarNomes(strMatrizNome);
                        }
                    }
                }
            }

            //Elimina os nomes abreviados caso o resultado ainda seja maior que o dejado
            intQtdOcc = 0;
            strRetorno = JuntarNomes(strMatrizNome);
            while (strRetorno.Length > intMaxCaracteres)
            {
                //separar novamente
                strMatrizNome = strRetorno.Split(new Char[] { ' ' });
                intQtdOcc = strMatrizNome.GetUpperBound(0);
                if (intQtdOcc > 1)
                {
                    //juntar tudo novamente
                    strRetorno = strMatrizNome[0];
                    for (int i = 2; i < intQtdOcc; i++)
                        strRetorno += " " + strMatrizNome[i];

                    strRetorno += " " + strMatrizNome[intQtdOcc];
                }
                else
                    break;
            }

            //Se o nome compactado permite o parentesco sem abreviação
            if (strParentesco != strParentescoAbrev)
            {
                intQtdOcc = strRetorno.Length - strParentescoAbrev.Length + strParentesco.Length;
                if (intQtdOcc <= intMaxCaracteres)
                {
                    //separar novamente
                    strMatrizNome = strRetorno.Split(new Char[] { ' ' });
                    intQtdOcc = strMatrizNome.GetUpperBound(0);
                    strMatrizNome[intQtdOcc] = strParentesco;
                    strRetorno = JuntarNomes(strMatrizNome);
                    return strRetorno;
                }
            }

            //Se após todas as tentativas o resultado ainda é maior que o desejado, remove a última letra
            while (strRetorno.Length > intMaxCaracteres)
                strRetorno = strRetorno.Substring(0, strRetorno.Length - 1);

            return strRetorno;
        }

        public static string RemoverNumeros(string texto)
        {
            try
            {
                if (!string.IsNullOrEmpty(texto))
                {
                    if (texto.Length > 0)
                    {
                        foreach (var caractere in LstNumeros)
                        {
                            texto = texto.Replace(caractere, string.Empty);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(Excecao.TratarMensagem(ex));
            }
            finally
            {
                LstCaracteresEspeciais = null;
            }

            return texto;
        }

        public static string RemoverDuploEspacamento(string texto)
        {
            string valorTratado = "";

            if (!string.IsNullOrEmpty(texto))
            {
                texto = texto.Replace("\r", "").Replace("\n", "");
                if (!string.IsNullOrEmpty(texto))
                {
                    valorTratado = ExpressoesRegulares.RgxDuploEspacamento.Replace(texto, @" ").TrimEnd().TrimStart();
                }
            }

            return valorTratado;
        }

        public static string RemoverCaracterEspecifico(string texto, char caractere)
        {
            string textoTratado = "";
            try
            {
                if (!string.IsNullOrEmpty(texto)                    
                    && texto.Length > 0)
                {
                    foreach (var letra in texto)
                    {
                        if (!letra.Equals(caractere))
                        {
                            textoTratado += letra;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException(Excecao.TratarMensagem(ex));
            }

            return textoTratado;
        }

        #region metodos auxiliares
        private static string JuntarNomes(string[] strMatrizNome)
        {
            //juntar tudo
            string strRetorno = strMatrizNome[0];
            for (int i = 1; i <= strMatrizNome.GetUpperBound(0); i++)
                strRetorno += " " + strMatrizNome[i];

            return strRetorno;
        }

        private static string AbreviarParentesco(string strNome)
        {
            string strRetorno = strNome;

            if (strNome == "JUNIOR")
                strRetorno = "JR";
            else if (strNome == "SOBRINHO")
                strRetorno = "SB";
            else if (strNome == "FILHO")
                strRetorno = "FO";
            else if (strNome == "NETO")
                strRetorno = "NT";

            return strRetorno;
        }
        #endregion metodos auxiliares
    }
}
