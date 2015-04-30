using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FWS.Ent
{
    [Serializable]
    public class eMensagem
    {
        [NotMapped]
        public bool? sucesso { get; set; }
        [NotMapped]
        public string mensagem { get; set; }
    }
}
