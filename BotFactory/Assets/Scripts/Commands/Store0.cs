using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Commands
{
    class Store0 : MemoryCommand
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
                return "Stores 0 in specyfic memory cell";
            }
        }

        public override CommandError Execute(Tank tank)
        {
            var commandToExecte = new StoreValue() { MemoryIndex = this.MemoryIndex, Argument = 0 };
            return commandToExecte.Execute(tank);
        }
    }
}
