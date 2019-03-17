using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using StrukturaDrzewiasta.Core.Domain;
using System.Data.Entity;


namespace StrukturaDrzewiasta.Persistance
{

    public class IdentityDatabaseContext : IdentityDbContext<User>
    {

        public IdentityDatabaseContext()
            : base("name=DatabaseContex")
        {
        }
  
        static IdentityDatabaseContext()
        {
            Database.SetInitializer<IdentityDatabaseContext>(new IdentityDbInit());
        }

        public static IdentityDatabaseContext Create()
        {
            return new IdentityDatabaseContext();
        }
    }

    //klasa incjalizacyjna dla IdentityDatabaseContext
    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<IdentityDatabaseContext>
    {

        protected override void Seed(IdentityDatabaseContext context)
        {
            AddDefaultUser(context);
            base.Seed(context);
        }

        //stworzenie jednego użytkownika, który będzie w bazie "na start"
        public void AddDefaultUser(IdentityDatabaseContext context)
        {
            AccountManager account = new AccountManager(new UserStore<User>(context));
            string userName = "admin";
            string password = "admin";
            string email = "admin@admin.com";
            User user = account.FindByName(userName);
            if (user == null)
            {
                account.Create(new User { UserName = userName, Email = email }, password);
                user = account.FindByName(userName);
            }
        }
    }
}