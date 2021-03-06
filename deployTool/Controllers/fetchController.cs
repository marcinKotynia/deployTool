﻿using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace deployTool.Controllers
{

    /// <summary>
    /// https://github.com/libgit2/libgit2sharp/wiki/git-fetch
    /// </summary>
    public class fetchController : ApiController
    {
        // GET: api/fetch
        public string Get()
        {
            return "RepositoryName";
        }

        // GET: api/fetch/5
        public string Get(string id)
        {
            return command(id);
        }

        // POST: api/fetch
        public void Post(string id,[FromBody]string value)
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

        public string command(string RepositoryName) {
            var configItem = WebApi.configuration.Where(x => x.repositoryName.Equals(RepositoryName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            if (configItem == null)
                throw new Exception(string.Format("Repository {0} not found", RepositoryName));

            deployTool.WebApi.logger.Debug("Command Start");

            string logMessage = "";
            

            using (var repo = new Repository(configItem.repositoryPath))
            {
                FetchOptions options = new FetchOptions();

                if (!string.IsNullOrEmpty(configItem.username))
                {
                    options.CredentialsProvider = new CredentialsHandler((url, usernameFromUrl, types) =>
                      new UsernamePasswordCredentials()
                      {
                          Username = configItem.username,
                          Password = configItem.password
                      });
                }
               

                foreach (Remote remote in repo.Network.Remotes)
                {
                    IEnumerable<string> refSpecs = remote.FetchRefSpecs.Select(x => x.Specification);
                    Commands.Fetch(repo, remote.Name, refSpecs, options, logMessage);
                }
            }
            deployTool.WebApi.logger.Debug("Command end");

            return logMessage;
        }

    }
}
