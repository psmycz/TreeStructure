using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using StrukturaDrzewiasta.Core.Domain;

namespace StrukturaDrzewiasta.Persistance
{
    //klasa odpowiedzilna za dane użytkowników
    public class AccountManager : UserManager<User>
    {
        //konstruktor wywołuje również bazowy z takimi samymi parametrzmi
        public AccountManager(IUserStore<User> store) 
            : base(store)
        {
        }

        //tworzenie instancji
        public static AccountManager Create(
            IdentityFactoryOptions<AccountManager> options,
            IOwinContext context)
        {
            //dostęp do bazy danych
            IdentityDatabaseContext db = context.Get<IdentityDatabaseContext>();
            //stworzenie obiektu z odpowiednimi danymi
            AccountManager manager = new AccountManager(new UserStore<User>(db));

            //walidacja danych dla hasła użytkownika
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireDigit = true,
                RequireUppercase = true,
            };

            //walidacja danych dla nazwy użytkownika
            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            //zwrócenie instancji klasy
            return manager;
        }
    }
}