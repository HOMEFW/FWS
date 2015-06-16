using System.Text.RegularExpressions;

namespace FWS.Helper.Converters
{
    public static class ExpressoesRegulares
    {

        private static Regex _rgxCpf;
        public static Regex RgxCpf
        {
            get
            {
                if (_rgxCpf == null)
                {
                    _rgxCpf = new Regex(@"(^(\d{3}.\d{3}.\d{3}-\d{2})|(\d{11})$)", RegexOptions.IgnoreCase);
                }

                return _rgxCpf;
            }
            set { _rgxCpf = value; }
        }

        private static Regex _rgxCnpj;
        public static Regex RgxCnpj
        {
            get
            {
                if (_rgxCnpj == null)
                {
                    _rgxCnpj = new Regex(@"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)", RegexOptions.IgnoreCase);
                }
                return _rgxCnpj;
            }
            set { _rgxCnpj = value; }
        }

        private static Regex _rgxRg;
        public static Regex RgxRg
        {
            get
            {
                if (_rgxRg == null)
                {
                    _rgxRg = new Regex(@"(^(\d{2}.\d{3}.\d{3}-(\w{1}|\w{0}))|(\d{8}(\w{1}|\w{0}))$)", RegexOptions.IgnoreCase);
                }
                return _rgxRg;
            }
            set { _rgxRg = value; }
        }

        private static Regex _rgxCnh;
        public static Regex RgxCnh
        {
            get
            {
                if (_rgxCnh == null)
                {
                    _rgxCnh = new Regex(@"(\d{9}|\d{11})", RegexOptions.IgnoreCase);
                }
                return _rgxCnh;
            }
            set { _rgxCnh = value; }
        }

        private static Regex _rgxNumeros;
        public static Regex RgxNumeros
        {
            get
            {
                if (_rgxNumeros == null)
                {
                    _rgxNumeros = new Regex(@"[0-9]", RegexOptions.IgnoreCase);
                }
                return _rgxNumeros;
            }
            set { _rgxNumeros = value; }
        }

        private static Regex _rgxLetras;
        public static Regex RgxLetras
        {
            get
            {
                if (_rgxLetras == null)
                {
                    _rgxLetras = new Regex(@"[a-zA-Z]", RegexOptions.IgnoreCase);
                }
                return _rgxLetras;
            }
            set { _rgxLetras = value; }
        }

        private static Regex _rgxEmail;
        public static Regex RgxEmail
        {
            get
            {
                if (_rgxEmail == null)
                {
                    _rgxEmail = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", RegexOptions.IgnoreCase);   
                }
                return _rgxEmail;
            }
            set { _rgxEmail = value; }
        }

        private static Regex _rgxDuploEspacamento;
        public static Regex RgxDuploEspacamento
        {
            get 
            {
                if (_rgxDuploEspacamento == null) 
                {
                    _rgxDuploEspacamento = new Regex(@"[ ]{2,}", RegexOptions.Multiline);
                }
                return _rgxDuploEspacamento; 
            }
            set { _rgxDuploEspacamento = value; }
        }

        private static Regex _rgxTelefone;
        public static Regex RgxTelefone
        {
            get 
            {
                if (_rgxTelefone == null) 
                {
                    _rgxTelefone = new Regex(@"/\((10)|([1-9][1-9])\) [2-9][0-9]{3}-[0-9]{4}/");
                }

                return _rgxTelefone; 
            }
            set { _rgxTelefone = value; }
        }

        private static Regex _rgxCep;        
        public static Regex RgxCep
        {
            get 
            {
                if (_rgxCep == null) 
                {
                    _rgxCep = new Regex(@"^\d{8}$");
                }

                return _rgxCep; 
            }
            set { _rgxCep = value; }
        }
    }
}
