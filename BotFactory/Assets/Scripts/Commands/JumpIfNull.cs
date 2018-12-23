using Assets.Scripts.Commands.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Commands
{
    class JumpIfNull : MemoryJumpCommand
    {
        public override string Description
        {
            get
            {
                return "Perform a program jump if certain memory cell is empty";
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

        protected override bool DirectConditionCheck(Tank tank)
        {
            if (tank.Memory[this.MemoryIndex] == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override bool IsVariableGoodType(Tank tank)
        {
            return true;
        }
    }
}
