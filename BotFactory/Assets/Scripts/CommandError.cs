using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts
{
    public class CommandError
    {
        public string Message { get; private set; }

        public CommandError(string message)
        {
            Message = message;
        }
    }
}
