using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Faberge.Web.Startup))]
namespace Faberge.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
