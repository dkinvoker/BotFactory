using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Commands
{
    abstract class MemoryJumpCommand : JumpCommand
    {
        public int MemoryIndex { get; set; } = 0;

        public sealed override CommandError Execute(Tank tank)
        {
            if (tank.Memory[MemoryIndex] == null)
            {
                return new CommandError($"Memory at {MemoryIndex} is Empty!");
            }
            else if (IsVariableGoodType(tank) == false)
            {
                return new CommandError($"Variable at {MemoryIndex} location is invalid type!");
            }
            else if (CheckCondition(tank))
            {
                tank.ProgramController.ProgramCounter = this.JumpPosition - 1;
            }
            return null;
        }

        protected abstract bool IsVariableGoodType(Tank tank);
    }
}
