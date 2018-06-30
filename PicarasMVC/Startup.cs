using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PicarasMVC.Startup))]
namespace PicarasMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
