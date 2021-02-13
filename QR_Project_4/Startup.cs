using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QR_Project_4.Startup))]
namespace QR_Project_4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
