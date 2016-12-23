using AlexaHelloWorld.Models;
using System;
using System.Threading;
using System.Web.Http;

namespace AlexaHelloWorld.Controllers
{
    public class DeskController : ApiController
    {
        [HttpGet, Route("api/desk/command")]
        public dynamic WaitCommand()
        {   
            int MaxWait = 100;
            int i = 0;
            while (!DeskManager.Instance.HasCommand() && i < MaxWait)
            {
                i++;
                Thread.Sleep(500);
                
            }

            return DeskManager.Instance.DequeueCommand();
        }

        [HttpPost, Route("api/desk/heightinfo")]
        public void UpdateCurrentHeight([FromBody]string height)//Nullable<int> height)
        {
            DeskManager.Instance.LastKnownHeight = Convert.ToInt32(height);
        }

        [HttpGet, Route("api/desk/command/peek")]
        public dynamic PeekCommand(dynamic request)
        {
            return DeskManager.Instance.PeekCommand();
        }
    }
}
