using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SetList.WebMVC.Startup))]
namespace SetList.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
