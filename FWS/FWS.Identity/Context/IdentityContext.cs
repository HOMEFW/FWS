using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using FWS.Identity.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using FWS.Identity.Entity;

namespace FWS.Identity.Context
{

    public class IdentityInitialize : InitializeDataBase<IdentityContext,Configuration>
    {
        internal void Initialize()
        {
            IdentityContext.Create();
        }
    }

    public class ApplicationUser : IdentityUser
    {
        [Required, StringLength(150)]
        public string Name { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }


    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext()
            : base(
                (Helper.Configuration.Config.ObterDadosBanco(Helper.Enumerators.BancoDados.BancoConexao.Fws)).ConexaoSql
                )
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserInfo> UserInfo { get; set; }

        public static IdentityContext Create()
        {
            const string name = "Administrator";
            const string email = "araujo.wg@hotmail.com";
            const string password = "1testes@";
            const string role = "UserManager";

            var context = new IdentityContext();

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("Financeira"))
                roleManager.Create(new IdentityRole("Financeira"));

            if (!roleManager.RoleExists("AdminFinanceira"))
                roleManager.Create(new IdentityRole("AdminFinanceira"));

            if (!roleManager.RoleExists("UserManager"))
                roleManager.Create(new IdentityRole("UserManager"));


            if (!roleManager.RoleExists(role))
            {
                var roleresult = roleManager.Create(new IdentityRole(role));
                if (!roleresult.Succeeded) return context;
            }

            var user = new ApplicationUser { UserName = email, Email = email, Name = name };
            var adminresult = userManager.CreateAsync(user, password);

            //Add User Admin to Role Admin
            if (adminresult.Result.Succeeded)
            {
                var result = userManager.AddToRole(user.Id, role);
                if (!result.Succeeded) return context;
            }

            context.UserInfo.AddOrUpdate(p => p.nome, new UserInfo() { memberId = user.Id, nome = name });
            context.SaveChanges();

            return context;

        }
    }
}
