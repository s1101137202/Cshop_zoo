using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(zoo.Startup))]
namespace zoo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
