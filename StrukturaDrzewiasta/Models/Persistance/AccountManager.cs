using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using StrukturaDrzewiasta.Core.Domain;

namespace StrukturaDrzewiasta.Persistance
{
    public class AccountManager : UserManager<User>
    {
        public AccountManager(IUserStore<User> store) 
            : base(store)
        {
        }

        public static AccountManager Create(
            IdentityFactoryOptions<AccountManager> options,
            IOwinContext context)
        {
            IdentityDatabaseContext db = context.Get<IdentityDatabaseContext>();
            AccountManager manager = new AccountManager(new UserStore<User>(db));

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireDigit = true,
                RequireUppercase = true,
            };

            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            return manager;
        }
    }
}