using System.Configuration;
using System.Reflection;
using System.Web.Http;
using Owin;
using Soardibot.Dto;

namespace Soardibot
{
    public class SoardiBotStart
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            Secrets secrets = Secrets.FromXmlString(Properties.Resources.secrets);

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            WebApiConfig.RegisterSecrets(config, secrets);
            appBuilder.UseWebApi(config);
        }
    }
}