using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Commands
{
    [Description("Redirect program flow to specific command number, if the tank is directly facing enemy tank")]
    class JumpIfFacingEnemy : JumpCommand
    {
        public override CommandError Execute(Tank tank)
        {
            throw new NotImplementedException();
        }
    }
}
