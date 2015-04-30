using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using FWS.Ent.Volcano;
using FWS.Dao.Migrations.Migrations_FWSVolcano;

namespace FWS.Dao.Context
{
    
    public class FwsVolcanoInitialize : InitializetDataBase<FwsVolcanoContext, ConfigurationFWSVolcano>
    {
        internal void Initialize()
        {
            FwsVolcanoContext.Create();
        }
    }

    public class FwsVolcanoContext : DbContext
    {
        public FwsVolcanoContext()
            : base("FwsVolcano")
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<FwsCrewContext>());
            //Database.Initialize(true);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Não cria tabelas com nomes pluralizados das entidades
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // Registra a classe Address como tipo complexo
            //modelBuilder.ComplexType<Address>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<eLancamentoGrupo> LancamentoGrupo { get; set; }
        public DbSet<eLancamentoTipo> LancamentoTipo { get; set; }

        public static FwsVolcanoContext Create()
        {
            var context = new FwsVolcanoContext();

            context.LancamentoGrupo.AddOrUpdate(t => t.descricao,
                new eLancamentoGrupo() { descricao = "Crédito", sigla = "C", tipo = 1 },
                new eLancamentoGrupo() { descricao = "Débito", sigla = "D", tipo = -1 });
            context.SaveChanges();

            context.LancamentoTipo.AddOrUpdate(t => t.descricao,
                new eLancamentoTipo()
                {
                    dataInicio = DateTime.Now,
                    descricao = "Alimentação",
                    status = "A",
                    lancamentoGrupoId =
                        context.LancamentoGrupo.Where(p => p.sigla.Equals("D"))
                            .Select(t => t.lancamentoGrupoId)
                            .SingleOrDefault()
                },
                new eLancamentoTipo()
                {
                    dataInicio = DateTime.Now,
                    descricao = "Vestuário",
                    status = "A",
                    lancamentoGrupoId = context.LancamentoGrupo.Where(p => p.sigla.Equals("D"))
                            .Select(t => t.lancamentoGrupoId)
                            .SingleOrDefault()
                });
            context.SaveChanges();

            return context;
        }
    }
}
