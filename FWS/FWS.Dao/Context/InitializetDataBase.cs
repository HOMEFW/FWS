using System.Data.Entity;
using System.Data.Entity.Migrations;
using FWS.Log;

namespace FWS.Dao.Context
{
    public abstract class InitializetDataBase<TD, TC>
        where TD : DbContext
        where TC : DbMigrationsConfiguration<TD>, new()
    {
        protected InitializetDataBase()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TD, TC>());
            appLog.LogMe(erro.Warning, null, this.GetType(), "Initialize - " + typeof(TD).Name);
        }
    }

    public class InitializeDataBase
    {
        public void Initialize()
        {
            new FwsCrewInitialize().Initialize();
            new FwsVolcanoInitialize().Initialize();
        }
    }
}
