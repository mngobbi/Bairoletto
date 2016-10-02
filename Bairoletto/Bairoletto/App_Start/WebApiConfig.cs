using Bairoletto.App_Start;
using Newtonsoft.Json;
using System.Web.Configuration;
using System.Web.Http;

namespace Bairoletto
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            var DefFormatter = new Newtonsoft.Json.JsonSerializerSettings();

            DefFormatter.Formatting = Newtonsoft.Json.Formatting.None;
            DefFormatter.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            DefFormatter.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            DefFormatter.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            DefFormatter.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;

            Newtonsoft.Json.JsonConvert.DefaultSettings = () => DefFormatter;
            config.Formatters.JsonFormatter.SerializerSettings = DefFormatter;

            // Web API routes
            config.MapHttpAttributeRoutes();

            //Remove XML Formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            var clientID = WebConfigurationManager.AppSettings["auth0:ClientId"];
            var clientSecret = WebConfigurationManager.AppSettings["auth0:ClientSecret"];

            config.MessageHandlers.Add(new JsonWebTokenValidationHandler()
            {
                Audience = clientID,
                SymmetricKey = clientSecret
            });
        }
    }
}
