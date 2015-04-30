using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace FWS.Ent.Volcano
{
    [DataContract]
    [Table("LancamentoTipo", Schema = "dbo")]
    public class eLancamentoTipo
    {

        [DataMember]
        [Key, Column("lancamentoTipoId", TypeName = "INT"), Display(Name = "Código do Tipo de Lançamento"), Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int lancamentoTipoId { get; set; }

        [DataMember]
        [Column("descricao"),  Display(Name = "Descrição"),  Required, MaxLength(100)]
        public string descricao { get; set; }
        
        [DataMember]
        [Column("dataInicio", TypeName = "DATETIME"), Display(Name = "Data de Início") , Required]
        public DateTime dataInicio { get; set; }

        [DataMember]
        [Column("dataTermino", TypeName = "DATETIME"), Display(Name = "Data de Término")]
        public DateTime? dataTermino { get; set; }
        

        [DataMember]
        [Column("status"),  Display(Name = "Situação"),  Required, MaxLength(1)]
        public string status { get; set; }

        //[tip_credito] [char](1) NULL,
        //[DataMember]
        //[Column("descricao"),  Display(Name = "Descrição"),  Required, MaxLength(100)]
        //public string descricao { get; set; }

        [DataMember]
        [Column("lancamentoGrupoId"),  Required]
        public  Int16 lancamentoGrupoId { get; set; }

        [ForeignKey("lancamentoGrupoId")]
        public eLancamentoGrupo eLancamentoGrupo { get; set; }


    }
}
