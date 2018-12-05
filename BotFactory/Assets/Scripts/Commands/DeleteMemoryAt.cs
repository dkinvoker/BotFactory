using Assets.Scripts.Commands.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    class DeleteMemoryAt : MemoryCommand
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
                return "Clears memory at specified location";
            }
        }

        public override CommandError Execute(Tank tank)
        {
            if (tank.Memory[MemoryIndex] == null)
            {
                return new CommandError($"Memory at {MemoryIndex} is empty. Cannot delete empty memory!");
            }
            else
            {
                tank.Memory.Variables[MemoryIndex] = null;
                return null;
            }
        }
    }
}
