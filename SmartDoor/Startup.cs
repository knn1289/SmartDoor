using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SmartDoor.Startup))]
namespace SmartDoor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
