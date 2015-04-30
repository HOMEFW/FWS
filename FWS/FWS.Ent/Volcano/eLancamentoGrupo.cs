using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace FWS.Ent.Volcano
{
    [DataContract]
    [Table("LancamentoGrupo", Schema = "dbo")]
    public class eLancamentoGrupo: eMensagem
    {
        [DataMember]
        [Key, Column("lancamentoGrupoId", TypeName = "SMALLINT"), Display(Name = "Código do Grupo de Lançamento"), Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 lancamentoGrupoId { get; set; }

        [DataMember]
        [Column("descricao"),  Display(Name = "Descrição"),  Required, MaxLength(100)]
        public string descricao { get; set; }
        
        [DataMember]
        [Column("sigla"), Display(Name = "Sigla") , Required, MaxLength(2)]
        public string sigla { get; set; }

        [DataMember]
        [Column("tipo", TypeName = "SMALLINT"), Display(Name = "tipo"), Required]
        public Int16 tipo { get; set; }

    }
}
