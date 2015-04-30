namespace FWS.Dao.Migrations.Migrations_FWSVolcano
{
    using System.Data.Entity.Migrations;

    public sealed class ConfigurationFWSVolcano : DbMigrationsConfiguration<Context.FwsVolcanoContext>
    {
        public ConfigurationFWSVolcano()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations\Migrations_FWSVolcano";
        }
        protected override void Seed(Context.FwsVolcanoContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //context.LancamentoGrupo.AddOrUpdate(t => t.descricao,
            //    new eLancamentoGrupo() { descricao = "Cr�dito", sigla = "C", tipo = 1 },
            //    new eLancamentoGrupo() { descricao = "D�bito", sigla = "D", tipo = -1 });
            //context.SaveChanges();
            //context.LancamentoTipo.AddOrUpdate(t => t.descricao,
            //    new eLancamentoTipo()
            //    {
            //        dataInicio = DateTime.Now,
            //        descricao = "Alimenta��o",
            //        status = "A",
            //        lancamentoGrupoId =
            //            context.LancamentoGrupo.Where(p => p.sigla.Equals("D"))
            //                .Select(t => t.lancamentoGrupoId)
            //                .SingleOrDefault()
            //    },
            //    new eLancamentoTipo()
            //    {
            //        dataInicio = DateTime.Now,
            //        descricao = "Vestu�rio",
            //        status = "A",
            //        lancamentoGrupoId = context.LancamentoGrupo.Where(p => p.sigla.Equals("D"))
            //                .Select(t => t.lancamentoGrupoId)
            //                .SingleOrDefault()
            //    });
            //context.SaveChanges();
        }
    }
}
