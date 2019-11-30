using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Park_Play.Startup))]
namespace Park_Play
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
