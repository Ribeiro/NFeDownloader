using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NFeDownloader.Startup))]
namespace NFeDownloader
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
