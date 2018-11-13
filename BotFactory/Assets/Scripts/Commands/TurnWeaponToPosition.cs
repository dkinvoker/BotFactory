using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Commands
{
    class TurnWeaponToPosition : MemoryCommand
    {
        public TurnWeaponToPosition(int memoryIndex) : base(memoryIndex)
        {
        }

        public override bool Execute(Tank tank)
        {
            throw new NotImplementedException();
        }
    }
}
