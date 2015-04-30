using System;
using System.Collections.Generic;

namespace FWS.Ent.User
{
    [Serializable]
    public class eTipoInteresse : eMensagem
    {
        /// <summary>
        /// Identificação do Tipo de Interesse
        /// </summary>
        public int tipoInteresseId { get; set; }

        /// <summary>
        /// Descrição do Tipo de Interesse
        /// </summary>
        public string descricao { get; set; }

        /// <summary>
        /// Indica se o Tipo de interesse está : (S) = ativo ou  (N) = inativo
        /// </summary>
        public string ativo { get; set; }

        /// <summary>
        /// Lista com os interesse cadastrados para este Tipo de Interesse.
        /// </summary>
        public IEnumerable<eInteresse> listaInteresses{ get; set; }
    }
}

