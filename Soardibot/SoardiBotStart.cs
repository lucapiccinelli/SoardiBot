using System.Web.Http;
using Owin;

namespace Soardibot
{
    public class SoardiBotStart
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            appBuilder.UseWebApi(config);
        }
    }
}