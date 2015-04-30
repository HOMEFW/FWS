using System;

namespace FWS.Ent.User
{
    [Serializable]
    public class eLogin : eMensagem
    {
        /// <summary>
        /// Identificação da pessoa
        /// </summary>
        public long pessoaId { get; set; }

        /// <summary>
        /// Descrição do email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Apelido utilizado pela pessoa
        /// </summary>
        public string Apelido { get; set; }

        /// <summary>
        /// Identificação da pessoa
        /// </summary>
        public string UniqueIdentifier { get; set; }

        /// <summary>
        /// Chave de acesso.
        /// </summary>
        public string key { get; set; }
    }
}
