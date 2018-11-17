using Assets.Scripts.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Commands
{
    abstract class MemoryCommand : Command
    {
        protected int _memoryIndex = 0;
    }
}
