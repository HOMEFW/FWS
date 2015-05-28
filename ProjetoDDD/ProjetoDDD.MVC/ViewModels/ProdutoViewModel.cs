using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ProjetoDDD.Domain.Entities;

namespace ProjetoDDD.MVC.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome"),
        MaxLength(150, ErrorMessage = "Máximo {0} caracteres"),
        MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        public string Nome { get; set; }
        
        [DataType(DataType.Currency),
        Range(typeof(decimal),"0","9999999999999"),
        Required(ErrorMessage = "Preencha um valor")]
        public decimal Valor { get; set; }

        [DisplayName("Disponível?") ]
        public bool Disponivel { get; set; }

        public int ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }
    }
}