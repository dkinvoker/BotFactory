using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Commands
{
    abstract class ArithmeticalMemoryCommand : MemoryCommand
    {
        public float Argument { get; set; }
    }
}
