using System;

namespace FWS.Ent.User
{
    [Serializable]
    public class ePessoaPhone : eMensagem
    {
        /// <summary>
        /// Identificação da Pessoa
        /// </summary>
        public long pessoaId { get; set; }

        /// <summary>
        /// Identificação do Telefone
        /// </summary>
        public int foneId { get; set; }
        
        /// <summary>
        /// DDI - Código de área do Pais onde o telefone está registrado.
        /// </summary>
        public string codigoPais { get; set; }

        /// <summary>
        /// DDD - Código de área da região/estado onde o telefone está registrado.
        /// </summary>
        public string codigoArea { get; set; }

        /// <summary>
        /// Número do telefone
        /// </summary>
        public string telefone { get; set; }

        /// <summary>
        /// Número do ramal do telefone
        /// </summary>
        public string ramal { get; set; }

        /// <summary>
        /// Disponibilizar o registro para vizualização de terceiros? (S) = Sim ou (N) = Não.
        /// </summary>
        public string publicar { get; set; }
    }
}

