using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    [CreateAssetMenu(fileName = "TurnWeaponToPosition", menuName = "Commands/Turn Weapon To Position")]
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
