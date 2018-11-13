using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Commands
{
    class DeleteMemoryAt : MemoryCommand
    {
        public DeleteMemoryAt(int memoryIndex) : base(memoryIndex)
        {
        }

        public override bool Execute(Tank tank)
        {
            if (tank.Memory[_memoryIndex] == null)
            {
                return false;
            }
            else
            {
                tank.Memory.StoreValue(null, _memoryIndex);
                return true;
            }
        }
    }
}
