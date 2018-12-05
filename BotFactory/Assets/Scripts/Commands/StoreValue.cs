using Assets.Scripts.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Commands
{
    class StoreValue : ArgumentMemoryCommand
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
                return "Stores value in specyfic data cell";
            }
        }

        public override CommandError Execute(Tank tank)
        {
            var memoryData = tank.Memory[MemoryIndex];
            if (memoryData != null)
            {
                return new CommandError($"Memory at {MemoryIndex} is not empty! Delete Temory at this location first!");
            }
            else
            {
                tank.Memory.StoreValue(new Number(this.Argument), MemoryIndex);
                return null;
            }
        }
    }
}
