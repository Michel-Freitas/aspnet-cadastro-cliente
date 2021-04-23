using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MC.CadastroCliente.UI.Web.Startup))]
namespace MC.CadastroCliente.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
