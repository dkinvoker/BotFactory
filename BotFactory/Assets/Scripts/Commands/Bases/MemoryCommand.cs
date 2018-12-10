using Assets.Scripts.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Commands.Bases
{
    abstract class MemoryCommand : Command
    {
        public int MemoryIndex { get; set; } = 0;
    }
}
