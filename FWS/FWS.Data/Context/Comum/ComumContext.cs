using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using FWS.Data.EntityConfig.Comum;
using FWS.Domain.Entities.Comum;

namespace FWS.Data.Context.Comum
{
    public class ComumContext : DbContext
    {
        public ComumContext():base("FWS"){}

        public DbSet<eDominio> Dominio { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Properties().Where(p => p.ReflectedType != null && p.Name == p.ReflectedType.Name + "Id").Configure(p => p.IsKey());
            modelBuilder.Configurations.Add(new DominioConfig());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;


                if (entry.State != EntityState.Modified) continue;
                entry.Property("DataCadastro").IsModified = false;
                entry.Property("UsuarioCadastroId").IsModified = false;
            }
            return base.SaveChanges();
        }



    }

}

