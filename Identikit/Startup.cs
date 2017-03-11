using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Identikit.Startup))]
namespace Identikit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
