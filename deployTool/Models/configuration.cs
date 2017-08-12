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

    public class Log {
        List<Models.LogItem> log { get; set; }

        public void AddItem(string repositoryName, string message)
        {
            if (log == null)
                log = new List<LogItem>();

            log.Add(new LogItem(repositoryName, message));

        }

    }
    

    public class LogItem
    {
        public DateTime logDate { get; set; }
        public string repositoryName { get; set; }
        public string message { get; set; }

        public LogItem(string _repositoryName,string _message)
        {
            logDate = DateTime.UtcNow;
            repositoryName = _repositoryName;
            message = _message;
        }
    }


}