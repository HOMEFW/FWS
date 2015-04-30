namespace FWS.Dao.Migrations.Migrations_FwsCrew
{
    using System.Data.Entity.Migrations;

    public sealed class ConfigurationFwsCrew : DbMigrationsConfiguration<Context.FwsCrewContext>
    {
        public ConfigurationFwsCrew()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations\Migrations_FwsCrew";
        }

        protected override void Seed(Context.FwsCrewContext context)
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
        }
    }
}
