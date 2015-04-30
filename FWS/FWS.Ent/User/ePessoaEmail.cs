using System;


namespace FWS.Ent.User
{
    [Serializable]
    public class ePessoaEmail :eMensagem
    {
        /// <summary>
        /// Identificação da Pessoa
        /// </summary>
        public long pessoaId { get; set; }

        /// <summary>
        /// Identificação do Email
        /// </summary>
        public long emailId { get; set; }

        /// <summary>
        /// Descrição do email
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// Disponibilizar o registro para vizualização de terceiros? (S) = Sim ou (N) = Não.
        /// </summary>
        public string publicar { get; set; }
    }
}

