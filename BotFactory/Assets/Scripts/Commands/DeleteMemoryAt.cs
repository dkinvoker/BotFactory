using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    [CreateAssetMenu(fileName = "DeleteMemoryAt", menuName = "Commands/Delete Memory At")]
    class DeleteMemoryAt : MemoryCommand
    {
        public DeleteMemoryAt(int memoryIndex) : base(memoryIndex)
        {
        }

        public override CommandType Type
        {
            get
            {
                return CommandType.PureMemory;
            }
        }

        public override CommandError Execute(Tank tank)
        {
            if (tank.Memory[_memoryIndex] == null)
            {
                return new CommandError($"Memory at {_memoryIndex} is empty. Cannot delete empty memory!");
            }
            else
            {
                tank.Memory.StoreValue(null, _memoryIndex);
                return null;
            }
        }
    }
}
