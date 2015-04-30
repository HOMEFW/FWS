using System;


namespace FWS.Ent.User
{
    [Serializable]
    public class ePessoa : eLogin
    {
        /// <summary>
        /// Nome da pessoa
        /// </summary>
        public string nome { get; set; }

        /// <summary>
        /// Sobrenome da pessoa
        /// </summary>
        public string sobrenome { get; set; }

        /// <summary>
        /// Data de Nascimento da pessoa
        /// </summary>
        public DateTime? dataNascimento { get; set; }

        /// <summary>
        /// Sexo da pessoa (M) masculino ou (F) feminino.
        /// </summary>
        public string sexo { get; set; }

        /// <summary>
        /// Estado civil da pessoa : (S)-solteiro(a) | (C)-casado(a) | (D)-divorciado(a) | (V)-víuvo(a) 
        /// </summary>
        public string estadoCivil { get; set; }

        /// <summary>
        /// Nome da imagem a exibir no perfil
        /// </summary>
        public byte?[] imagem { get; set; }

        /// <summary>
        /// Informa se o perfil está ativa. (S) = sim ou (N) = não
        /// </summary>
        public string contaAtiva { get; set; }

        /// <summary>
        /// Informa se a conta está bloqueada (S) = sim ou (N) = não
        /// </summary>
        public string acessoLiberado { get; set; }

        /// <summary>
        /// informa a quantidade de tentativas de acesso invalidas utilizando o email do usuário.
        /// </summary>
        public int tentativaAcesso { get; set; }

        /// <summary>
        /// Identificação da pessoa (anfitriã) que emitiu o convite para esta pessoa (convidada).
        /// </summary>
        public int pessoaConviteId { get; set; }

        /// <summary>
        /// indica se estas informações podem ser visualizadas por outras pessoas (S) = sim ou (N) = não.
        /// </summary>
        public string publicar { get; set; }

    }
}
