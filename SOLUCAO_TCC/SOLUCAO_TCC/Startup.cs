using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SOLUCAO_TCC.Startup))]
namespace SOLUCAO_TCC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
