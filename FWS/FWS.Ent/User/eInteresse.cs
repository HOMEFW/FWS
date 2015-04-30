using System;


namespace FWS.Ent.User
{
    [Serializable]
    public class eInteresse : eMensagem
    {
        /// <summary>
        /// Identificação do interesse
        /// </summary>
        public int interesseId { get; set; }
        
        /// <summary>
        /// Identificação do Tipo de interesse 
        /// </summary>
        public int tipoInteresseId { get; set; }

        /// <summary>
        /// Descrição do interesse
        /// </summary>
        public string descricao { get; set; }

        /// <summary>
        /// indica se o interesse deverá estar disponivel para seleção da pessoa (S) = sim ou (N) = não.
        /// </summary>
        public string ativo { get; set; }
    }
}
