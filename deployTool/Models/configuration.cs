using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace deployTool.Models
{

    public class ConfigurationItem
    {
        public string repositoryName { get; set; }
        public string repositoryPath { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string logMessage { get; set; }  //last Message
    }

  


}