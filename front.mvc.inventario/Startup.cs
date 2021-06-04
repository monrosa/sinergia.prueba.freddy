using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(front.mvc.inventario.Startup))]
namespace front.mvc.inventario
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
