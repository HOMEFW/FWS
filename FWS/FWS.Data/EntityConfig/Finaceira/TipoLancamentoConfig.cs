using System.Data.Entity.ModelConfiguration;
using FWS.Domain.Entities.Financeira;

namespace FWS.Data.EntityConfig.Finaceira
{
    public class TipoLancamentoConfig:EntityTypeConfiguration<eTipoLancamento>
    {
        public TipoLancamentoConfig()
        {
            HasKey(c => c.TipoLancamentoId);
            Property(c => c.Descricao)
                .HasMaxLength(200)
                .IsRequired();
            Property(c => c.Ativo)
                .HasMaxLength(1)
                .IsRequired();
            Property(c => c.GrupoLancamentoId)
                .IsRequired();
        }

        //public int TipoLancamentoId { get; set; }
        //public string Descricao { get; set; }
        //public DateTime DataInicio { get; set; }
        //public DateTime? DataTermino { get; set; }
        //public string Ativo { get; set; }
        //public Int16 GrupoLancamentoId { get; set; }
    }
}
