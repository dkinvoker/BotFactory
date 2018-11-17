using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    [Description("Turns the tank weapon left or right dependig on the position stored in memory cell")]
    class TurnWeaponToPosition : MemoryCommand
    {
        public TurnWeaponToPosition(int memoryIndex) : base(memoryIndex)
        {
        }

        public override CommandType Type
        {
            get
            {
                return CommandType.WeaponRotation;
            }
        }

        public override CommandError Execute(Tank tank)
        {
            throw new NotImplementedException();
        }
    }
}
