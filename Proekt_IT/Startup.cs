using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Proekt_IT.Startup))]
namespace Proekt_IT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
