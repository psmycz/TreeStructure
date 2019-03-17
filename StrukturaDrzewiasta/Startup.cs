using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(StrukturaDrzewiasta.Startup))]

namespace StrukturaDrzewiasta
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Aby uzyskać więcej informacji o sposobie konfigurowania aplikacji, odwiedź stronę https://go.microsoft.com/fwlink/?LinkID=316888

        }
    }
}
