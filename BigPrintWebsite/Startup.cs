using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BigPrintWebsite.Startup))]
namespace BigPrintWebsite
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
