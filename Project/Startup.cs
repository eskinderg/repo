using Microsoft.Owin;
using Owin;
using Project.App_Start;

[assembly: OwinStartupAttribute(typeof(Project.Startup))]
namespace Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Bootstrapper.Run();
            ConfigureAuth(app);
        }
    }
}
