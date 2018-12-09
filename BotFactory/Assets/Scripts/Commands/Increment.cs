using Assets.Scripts.Commands.Bases;
using Assets.Scripts.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Commands
{
    class Increment : MemoryCommand
    {
        public override CommandType Type
        {
            get
            {
                return CommandType.PureMemory;
            }
        }

        public override string Description
        {
            get
            {
                return "Adds 1 to value in specyfic memory cell";
            }
        }

        public override CommandError Execute(Tank tank)
        {
            var memoryData = tank.Memory[MemoryIndex];
            if (memoryData == null)
            {
                return new CommandError($"Memory at location {MemoryIndex} is empty!");
            }
            else if (!(memoryData is Number))
            {
                return new CommandError($"Memory at location {MemoryIndex} is not numeric type!");
            }
            else
            {
                var number = memoryData as Number;
                 number += 1;
                return null;
            }
        }
    }
}
