using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Commands
{
    class Jump : JumpCommand
    {
        public override string Description
        {
            get
            {
                return "Redirect program flow to specific command number";
            }
        }

        protected override bool DirectConditionCheck(Tank tank)
        {
            return true;
        }
    }
}
