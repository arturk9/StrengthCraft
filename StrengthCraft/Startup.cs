using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StrengthCraft.Startup))]
namespace StrengthCraft
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
