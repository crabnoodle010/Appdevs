using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ManagerFPTs.Startup))]
namespace ManagerFPTs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
