using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Parkme.Startup))]
namespace Parkme
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
