using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace FWS.Ent.Crew
{
    [DataContract]
    [Table("UserInfo", Schema = "dbo")]
    public class eUserInfo :  eMensagem
    {
        [DataMember]
        [Key, Column("userId",TypeName = "BIGINT"), Display(Name = "Código do usuário"), Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long userId { get; set; }
        [DataMember]
        [Column("memberId"), Required, MaxLength(128)]
        public string memberId { get; set; }       
        [DataMember]
        [Column("nome"),  Display(Name = "Nome do Usuário"), Required, MaxLength(150)]
        public string nome { get; set; }
        
        //[DataMember]
        //[Column("imagem"), Display(Name = "Image"), Required, MaxLength(150)]
        //public byte[] imagem { get; set; }
        
    }
}
