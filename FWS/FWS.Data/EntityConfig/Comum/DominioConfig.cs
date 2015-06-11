using System.Data.Entity.ModelConfiguration;
using FWS.Domain.Entities.Comum;

namespace FWS.Data.EntityConfig.Comum
{
    public class DominioConfig:EntityTypeConfiguration<eDominio>
    {


        public DominioConfig()
        {
            
            HasKey(c => c.DominioId);

            Property(c => c.Codigo)
                .IsRequired();

            Property(c => c.Nome)
                .HasMaxLength(100)
                .IsRequired();

            Property(c => c.Alias)
                .HasMaxLength(100)
                .IsRequired();

            Property(c => c.DataCadastro)
                .IsRequired();

            //HasRequired(p => p.Usuario)
            //    .WithMany()
            //    .HasForeignKey(p => p.UsuarioCadastroId);



        }
        //public int DominioId { get; set; }
        //public int Codigo { get; set; }
        //public string Nome { get; set; }
        //public string Alias { get; set; }
        //public string Ativo { get; set; }
        //public DateTime DataCadastro { get; set; }
        //public int UsuarioCadastroId { get; set; }
    }
}
