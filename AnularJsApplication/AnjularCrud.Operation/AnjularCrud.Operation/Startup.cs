using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnjularCrud.Operation.Startup))]
namespace AnjularCrud.Operation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
