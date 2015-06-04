using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GALU_ERP.Startup))]
namespace GALU_ERP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
