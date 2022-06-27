using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ElkaApp.Startup))]
namespace ElkaApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
