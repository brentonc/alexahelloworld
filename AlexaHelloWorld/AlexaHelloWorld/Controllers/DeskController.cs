using AlexaHelloWorld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace AlexaHelloWorld.Controllers
{
    public class DeskController : ApiController
    {
        [HttpGet, Route("api/desk/command")]
        public dynamic WaitCommand(dynamic request)
        {   
            
            while (!DeskManager.Instance.HasCommand())
            {
                Thread.Sleep(1000);
            }

            return DeskManager.Instance.DequeueCommand();
        }

        [HttpGet, Route("api/desk/command/peek")]
        public dynamic PeekCommand(dynamic request)
        {
            return DeskManager.Instance.PeekCommand();
        }
    }
}
