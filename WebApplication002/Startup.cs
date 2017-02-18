using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApplication002.Startup))]
namespace WebApplication002
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
