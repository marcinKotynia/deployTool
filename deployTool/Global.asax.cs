using NLog;
using System.Collections.Generic;
using System.Web.Http;
using YamlDotNet.Serialization;

namespace deployTool
{
    public class WebApi : System.Web.HttpApplication
    {
        public static List<Models.ConfigurationItem> configuration = new List<Models.ConfigurationItem>();
        public static Logger logger = LogManager.GetCurrentClassLogger();

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);


            deployTool.WebApi.logger.Debug("Start");

            var deserializer = new YamlDotNet.Serialization.Deserializer();
            var mappedPath = System.Web.Hosting.HostingEnvironment.MapPath("~/config.yaml");

            string config = System.IO.File.ReadAllText(mappedPath);
            configuration  = deserializer.Deserialize<List<Models.ConfigurationItem>>(config);
            

        }
    }
}
