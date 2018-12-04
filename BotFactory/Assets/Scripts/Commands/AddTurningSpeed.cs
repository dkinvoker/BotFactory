﻿using Assets.Scripts.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Commands
{
    class AddTurningSpeed : MemoryCommand
    {
        public override CommandType Type
        {
            get
            {
                return CommandType.PureMemory;
            }
        }

        public override CommandError Execute(Tank tank)
        {
            var memoryData = tank.Memory[MemoryIndex];

            if (memoryData == null)
            {
                return new CommandError($"Memory at {MemoryIndex} is empty!");
            }
            else if (!(memoryData is Number))
            {
                return new CommandError($"Variable at {MemoryIndex} have to be Numerical Type");
            }
            else
            {
                var casting = memoryData as Number;
                casting += new Number(tank.Wheels.TurningSpeed);
                return null;
            }
        }
    }
}
