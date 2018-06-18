using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fabryka.Startup))]
namespace Fabryka
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
