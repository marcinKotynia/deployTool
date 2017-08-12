using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace deployTool.Controllers
{

    public class mainController : ApiController
    {
        // GET: api/fetch
        public string Get()
        {
            return "Deploy Tool Hello";
        }

   
    }
}
