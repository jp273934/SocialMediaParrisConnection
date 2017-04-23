using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ParrisConnection.Startup))]
namespace ParrisConnection
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
          

            ConfigureAuth(app);
        }
    }
}
