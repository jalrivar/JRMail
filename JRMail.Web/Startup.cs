using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JRMail.Web.Startup))]
namespace JRMail.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
