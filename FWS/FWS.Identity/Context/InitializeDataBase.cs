using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FWS.Identity.Context
{
    public abstract class InitializeDataBase<TD, TC>
        where TD : DbContext
        where TC : DbMigrationsConfiguration<TD>, new()
    {
        protected InitializeDataBase()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TD, TC>());
            //appLog.LogMe(erro.Warning, null, GetType(), "Initialize - " + typeof(TD).Name);
        }
    }

    public class InitializeDataBase
    {
        public void Initialize()
        {
            new IdentityInitialize().Initialize();
        }
    }
    class Initialize
    {
    }
}
