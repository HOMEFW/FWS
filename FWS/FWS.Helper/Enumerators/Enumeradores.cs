namespace FWS.Helper.Enumerators
{
    public static class Enumeradores
    {
        public enum Ambiente
        {
            Local = 1,
            Desenvolvimento = 2,
            Homologação = 3,
            QA = 4,
            Producao = 5
        }



        /// <summary>
        /// Usado na validação de documentos. Ex: CPF, RG, CNH
        /// </summary>
        public enum Documento
        {
            CPF = 1,
            RG = 2,
            CNPJ = 3,
            CNH = 4
        }

        public enum NomeSessao 
        {
            SCA_SESSION_USUARIO = 1
        }

    }
}
