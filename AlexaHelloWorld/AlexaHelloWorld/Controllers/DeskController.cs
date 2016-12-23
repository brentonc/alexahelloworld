using AlexaHelloWorld.Models;
using System.Threading;
using System.Web.Http;

namespace AlexaHelloWorld.Controllers
{
    public class DeskController : ApiController
    {
        [HttpGet, Route("api/desk/command")]
        public dynamic WaitCommand(dynamic request)
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

        [HttpGet, Route("api/desk/command/peek")]
        public dynamic PeekCommand(dynamic request)
        {
            return DeskManager.Instance.PeekCommand();
        }
    }
}
