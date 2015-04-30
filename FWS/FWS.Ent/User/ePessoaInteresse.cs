using System;


namespace FWS.Ent.User
{
    [Serializable]
    public class ePessoaInteresse : eMensagem
    {
        /// <summary>
        /// Identificação da Pessoa
        /// </summary>
        public long pessoaId { get; set; }

        /// <summary>
        /// Identificação do Interesse.
        /// </summary>
        public int interesseId { get; set; }
    }
}

