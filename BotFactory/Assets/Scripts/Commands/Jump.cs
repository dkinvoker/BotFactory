using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Commands
{
    [Description("Redirect program flow to specific command number")]
    class Jump : JumpCommand
    {
        protected override bool DirectConditionCheck(Tank tank)
        {
            return true;
        }
    }
}
