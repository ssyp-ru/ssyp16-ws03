using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IFK.Server.Startup))]
namespace IFK.Server
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
