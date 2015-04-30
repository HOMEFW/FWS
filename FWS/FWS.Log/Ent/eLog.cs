using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FWS.Log.Ent
{
    [Serializable]
    [Table("BUSTED")]
    public class eLog
    {
        //public int? logId { get; set; }
        //public DateTime? Data { get; set; }
        //public int Level { get; set; }
        //public string Classe { get; set; }
        //public string Metodo { get; set; }
        //public string Mensagem { get; set; }
        //public string Message { get; set; }
        //public string Stack { get; set; }
        [Key]
        public long? logId { get; set; }

        public int Level { get; set; }

        public DateTime? Data { get; set; }

        [Column("Classe"), Display(Name = @"Classe ocorrência"), StringLength(50, MinimumLength = 1)]
        public string Classe { get; set; }

        [StringLength(50) ]
        public string Metodo { get; set; }

        [StringLength(500)]
        public string Mensagem { get; set; }

        [StringLength(500)]
        public string Message { get; set; }

        [StringLength(500)]
        public string Stack { get; set; }


    }
}
