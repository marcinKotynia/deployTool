using System.Collections.Generic;
using System.Web.Http;
using YamlDotNet.Serialization;

namespace deployTool
{
    public class WebApi : System.Web.HttpApplication
    {
        public static Models.Log log = new Models.Log();
        public static List<Models.ConfigurationItem> configuration = new List<Models.ConfigurationItem>();


        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            WebApi.log.AddItem("", "Start");

            var deserializer = new YamlDotNet.Serialization.Deserializer();
            var mappedPath = System.Web.Hosting.HostingEnvironment.MapPath("~/config.yaml");

            string config = System.IO.File.ReadAllText(mappedPath);
            configuration  = deserializer.Deserialize<List<Models.ConfigurationItem>>(config);
            

        }
    }
}
