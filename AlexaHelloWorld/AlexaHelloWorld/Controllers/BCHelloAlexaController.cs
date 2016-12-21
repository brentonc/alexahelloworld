using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AlexaHelloWorld.Controllers
{
    public class BCHelloAlexaController : ApiController
    {
        [HttpPost, Route("api/alexa/hello")]
        public dynamic HCHelloAlexa(dynamic request)
        {

            return new
            {
                version = "1.0",
                sessionAttributes = new { },
                response = new
                {
                    outputSpeech = new
                    {
                        type = "text",
                        text = "Hello Brenton"
                    },
                    card = new
                    {
                        type = "Simple",
                        title = "BC Hello Alexa Skill",
                        content = "Hello Brenton\nIsn't this fun?"
                    },
                    shouldEndSession = true
                }
            };

            /*  RESPONSE SCHEMA
             {
  "version": "string",
  "sessionAttributes": {
    "string": object
  },
  "response": {
    "outputSpeech": {
      "type": "string",
      "text": "string",
      "ssml": "string"
    },
    "card": {
      "type": "string",
      "title": "string",
      "content": "string",
      "text": "string",
      "image": {
        "smallImageUrl": "string",
        "largeImageUrl": "string"
      }
    },
    "reprompt": {
      "outputSpeech": {
        "type": "string",
        "text": "string",
        "ssml": "string"
      }
    },
    "directives": [
      {
        "type": "string",
        "playBehavior": "string",
        "audioItem": {
          "stream": {
            "token": "string",
            "url": "string",
            "offsetInMilliseconds": 0
          }
        }
      }
    ],
    "shouldEndSession": boolean
  }
} 
             */
        }
    }
}
