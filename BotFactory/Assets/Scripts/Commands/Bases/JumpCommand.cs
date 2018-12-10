using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Commands.Bases
{
    abstract class JumpCommand : Command
    {
        public int JumpPosition { get; set; } = 0;
        public bool Negate { get; set; } = false;

        public override CommandType Type
        {
            get
            {
                return CommandType.Jump;
            }
        }

        public override CommandError Execute(Tank tank)
        {
            if (CheckCondition(tank))
            {
                tank.ProgramController.ProgramCounter = this.JumpPosition - 1;
            }
            return null;
        }

        protected abstract bool DirectConditionCheck(Tank tank);

        protected bool CheckCondition(Tank tank)
        {
            if (Negate)
            {
                return !DirectConditionCheck(tank);
            }
            else
            {
                return DirectConditionCheck(tank);
            }
        }

    }
}
