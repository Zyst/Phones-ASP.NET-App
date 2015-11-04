using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Phoneify.Startup))]
namespace Phoneify
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
