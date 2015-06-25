using System.Security.Claims;
using System.Threading.Tasks;
using FWS.Helper.Configuration;
using FWS.Helper.Enumerators;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FWS.MVC.Areas.Users.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            //: base("DefaultConnection", throwIfV1Schema: false)
        {

            base.Database.Connection.ConnectionString =
                Config.ObterDadosBanco(BancoDados.BancoConexao.Fws).GetConexao;
        }

        public static ApplicationDbContext Create()
        {
            const string name = "Administrator";
            const string email = "araujo.wg@hotmail.com";
            const string password = "1testes@";
            const string role = "Admin";

            var context = new ApplicationDbContext();

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("Financeira"))
                roleManager.Create(new IdentityRole("Financeira"));

            if (!roleManager.RoleExists("AdminFinanceira"))
                roleManager.Create(new IdentityRole("AdminFinanceira"));


            if (!roleManager.RoleExists(role))
            {
                var roleresult = roleManager.Create(new IdentityRole(role));
                if (!roleresult.Succeeded) return context;
            }

            var user = new ApplicationUser { UserName = email, Email = email};
            //var adminresult = userManager.CreateAsync(user, password);
            var adminresult = userManager.Create(user, password);

            //Add User Admin to Role Admin
            if (!adminresult.Succeeded) return context;

            var result = userManager.AddToRole(user.Id, role);
            if (!result.Succeeded) return context;
            context.SaveChanges();
            return context;
        }
    }
}