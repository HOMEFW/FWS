using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using FWS.Domain.Entities.Financeira;

namespace FWS.Data.Context.Financeira
{
    public class FinanceiraContext :DbContext
    {
        public FinanceiraContext() : base("FWS") { }

        public DbSet<eLancamento> Lancamento { get; set; }
        public DbSet<eTipoLancamento> TipoLancamento { get; set; }
        public DbSet<eGrupoLancamento> GrupoLancamento { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Properties()
                .Where(p => p.ReflectedType != null && p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(e => e.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;

                if(entry.State != EntityState.Modified) continue;
                entry.Property("DataCadastro").IsModified = false;
                entry.Property("UsuarioCadastroId").IsModified = false;
            }
            return base.SaveChanges();
        }


    }
}

