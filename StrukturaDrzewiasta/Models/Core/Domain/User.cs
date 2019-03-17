using Microsoft.AspNet.Identity.EntityFramework;

namespace StrukturaDrzewiasta.Core.Domain
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}