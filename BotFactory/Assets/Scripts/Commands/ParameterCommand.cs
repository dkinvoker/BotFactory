using Assets.Scripts.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Commands
{
    abstract class ParameterCommand : Command
    {

        public override bool Execute(Tank tank)
        {
            throw new NotImplementedException();
        }
    }
}
