using System;

namespace FWS.Ent.User
{
    [Serializable]
    public class ePessoaConvite :  eMensagem
    {
        /// <summary>
        /// Identificação do Convite.
        /// </summary>
        public int conviteId { get; set; }

        /// <summary>
        /// Identificação da pessoa que emitiu o convite.
        /// </summary>
        public long pessoaId { get; set; }

        /// <summary>
        /// Descrição do email do convidado.
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// Informa se o link do convite foi acessado (S) = sim ou (N) = não.
        /// </summary>
        public string acessado { get; set; }

        /// <summary>
        /// Informa se a convidado realizou o cadastro (S) = sim ou (N) = não.
        /// </summary>
        public string resgitrado { get; set; }

        /// <summary>
        /// Informa se o convite foi enviado para o email cadastrado (S) = sim ou (N) = não.
        /// </summary>
        public string enviado { get; set; }

        /// <summary>
        /// Mensagem enviada junto ao convite.
        /// </summary>
        public string mensagemConvite { get; set; }

    }
}

