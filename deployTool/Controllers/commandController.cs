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
            return "OK";
        }

        // GET: api/fetch/5
        public string Get(string id)
        {
             command(id);
            return "OK";
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

        public void command(string commanditem)
        {
            var configItem = WebApi.configuration.Where(x => x.repositoryName.Equals(commanditem, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            if (configItem == null)
                deployTool.WebApi.logger.Error(string.Format("Command {0} not found", commanditem));
            
            deployTool.WebApi.logger.Debug("Command Start " + commanditem);
            
       
            var processInfo = new ProcessStartInfo("cmd.exe", "/c " + configItem.repositoryPath);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            var process = Process.Start(processInfo);
            //* Read the output (or the error)
            //string output = process.StandardOutput.ReadToEnd();
            //deployTool.WebApi.logger.Debug(output);
            //string err = process.StandardError.ReadToEnd();
            //deployTool.WebApi.logger.Error(err);

            process.OutputDataReceived += (object sender, DataReceivedEventArgs e) =>
                   deployTool.WebApi.logger.Debug(e.Data);
            process.BeginOutputReadLine();

            process.ErrorDataReceived += (object sender, DataReceivedEventArgs e) =>
                deployTool.WebApi.logger.Error(e.Data);
            process.BeginErrorReadLine();

            process.WaitForExit();
            
            process.Close();


            deployTool.WebApi.logger.Debug("Command End "+ commanditem);
            
        }

    }
}
