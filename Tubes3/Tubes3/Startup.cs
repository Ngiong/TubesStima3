using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tubes3.Startup))]
namespace Tubes3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
