using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlexaHelloWorld.Models
{
    public class DeskManager
    {

        private static DeskManager _mgr = new DeskManager();

        private Command _command;

        private DeskManager()
        {
            _command = null;
            Updated = DateTime.MinValue;
        }

        public static DeskManager Instance
        {
            get
            {
                return _mgr;
            }
        }

        public bool HasCommand()
        {
            return !(_command == null);
        }
        public void EnqueueCommand(Command command)
        {
            _command = command;
            Updated = DateTime.Now;
        }

        public Command DequeueCommand()
        {
            var response = _command;
            _command = null;
            return response;
        }

        public Command PeekCommand()
        {
            return _command;
        }
        
        public DateTime Updated { get; set; }
    }

    public class Command
    {
        public string CommandCode { get; set; }
        public string CommandArg { get; set; }
    }
}