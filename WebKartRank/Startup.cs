using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebKartRank.Startup))]
namespace WebKartRank
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
