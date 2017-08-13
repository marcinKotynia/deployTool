using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;

namespace deployTool.Controllers
{

    /// <summary>
    /// https://github.com/libgit2/libgit2sharp/wiki/git-fetch
    /// </summary>
    public class commandController : ApiController
    {
        // GET: api/fetch
        public string Get()
        {
            return "Command";
        }

        // GET: api/fetch/5
        public string Get(string id)
        {
            return command(id);
        }

        // POST: api/fetch
        public void Post(string id, [FromBody]string value)
        {
            command(id);
        }

        // PUT: api/fetch/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        // DELETE: api/fetch/5
        //public void Delete(int id)
        //{
        //}

        public string command(string commanditem)
        {
            var configItem = WebApi.configuration.Where(x => x.repositoryName.Equals(commanditem, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            if (configItem == null)
                throw new Exception(string.Format("Command {0} not found", commanditem));

            WebApi.log.AddItem(commanditem, "Command Start");

            string logMessage = "";

            string command = "";
            var processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            var process = Process.Start(processInfo);

            process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
                Console.WriteLine("output>>" + e.Data);
            process.BeginOutputReadLine();

            process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
                Console.WriteLine("error>>" + e.Data);
            process.BeginErrorReadLine();

            process.WaitForExit();

            Console.WriteLine("ExitCode: {0}", process.ExitCode);
            process.Close();



            WebApi.log.AddItem(commanditem, "Command End");

            return logMessage;
        }

    }
}
