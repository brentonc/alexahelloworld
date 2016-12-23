using System;
using System.Web.Http;
using Alexa.Contracts;
using System.Linq;
using AlexaHelloWorld.Models;

namespace AlexaHelloWorld.Controllers
{
    public class AlexaController : ApiController
    {
        [HttpPost, Route("api/1_0/alexa")]
        public dynamic AlexaRequestEndpoint(AlexaRequest request)
        {
            AlexaResponse response;
            switch (request.Request.Intent.Name)
            {
                case "HelloRobotDeskIntent":
                    response = InvokeHelloIntent(request);
                    break;
                case "SetDeskHeightIntent":
                    response = InvokeSetDeskHeightIntent(request);
                    break;
                case "ResetDeskIntent":
                    response = InvokeResetDeskIntent(request);
                    break;
                case "GetDeskHeightIntent":
                default:
                    response = InvokeGetDeskHeightIntent(request);
                    break;

            }
            return response;

        }

        private AlexaResponse InvokeResetDeskIntent(AlexaRequest request)
        {
            DeskManager.Instance.EnqueueCommand(new Command() { CommandCode = "RESET" });
            return new AlexaResponse($"Ok, I am resetting RobotDesk for you.");
        }

        private AlexaResponse InvokeGetDeskHeightIntent(AlexaRequest request)
        {
            return new AlexaResponse("You asked to get the desk height");
        }

        private AlexaResponse InvokeSetDeskHeightIntent(AlexaRequest request)
        {
            var slots = request.Request.Intent.GetSlots();
            AlexaResponse response = null;
            if (slots.Count < 1)
            {
                response = new AlexaResponse("You asked to set the desk height, but I don't understand what height you want.");
            }
            else
            {
                int height;
                if (int.TryParse(slots.FirstOrDefault(s => s.Key == "height").Value, out height))
                {
                    DeskManager.Instance.EnqueueCommand(new Command() { CommandCode = "MOVE", CommandArg = height.ToString() });

                    response = new AlexaResponse($"Sure, I am moving RobotDesk to {height} inches.");
                }
                else
                {
                    response = new AlexaResponse("You asked to set the desk height, but I don't understand what height you want.");
                }
            }

            return response;
        }

        private AlexaResponse InvokeHelloIntent(AlexaRequest request)
        {
            return new AlexaResponse("Hello Brenton");
        }
    }
}
