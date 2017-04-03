using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchoolSystem.Web.Startup))]
namespace SchoolSystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
