using Assets.Scripts.Commands.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Commands
{
    class ClearMemory : SimpleCommand
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
                return "Cleares all memory cells";
            }
        }

        public override CommandError Execute(Tank tank)
        {
            for (int i = 0; i < tank.Memory.Count; ++i)
            {
                tank.Memory.Variables[i] = null;
            }
            return null;
        }
    }
}
