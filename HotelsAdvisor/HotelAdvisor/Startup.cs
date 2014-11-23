using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HotelsAdvisor.Startup))]
namespace HotelsAdvisor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
