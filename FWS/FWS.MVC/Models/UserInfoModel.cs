using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FWS.MVC.Models
{
    [Table("UserInfo", Schema = "dbo")]
    public class UserInfoModel
    {
        [Key, Column("userId",TypeName = "BIGINT"), Display(Name = "Código do usuário"), Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long userId { get; set; }
        [Column("memberId"), Required, MaxLength(128)]
        public string memberId { get; set; }       
        [Column("nome"),  Display(Name = "Nome do Usuário"), Required, MaxLength(150)]
        public string nome { get; set; }
    }
}
