using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CatDaze.Startup))]
namespace CatDaze
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
