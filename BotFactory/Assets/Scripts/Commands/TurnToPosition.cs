using Assets.Scripts.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    [CreateAssetMenu(fileName = "TurnToPosition", menuName = "Commands/Turn To Position")]
    class TurnToPosition : MemoryCommand
    {
        public TurnToPosition(int memoryIndex) : base(memoryIndex)
        {
        }

        public override CommandType Type
        {
            get
            {
                return CommandType.Rotation;
            }
        }

        public override CommandError Execute(Tank tank)
        {
            var memoryData = tank.Memory[_memoryIndex];
            if (memoryData == null)
            {
                return new CommandError("Memory at" + _memoryIndex + " is empty");
            }
            else if ( !(memoryData is Position) )
            {
                return new CommandError("Memory at" + _memoryIndex + " is not a Position type");
            }
            else
            {
                var yourPosition = tank.transform.position;
                var enemyPosition = (memoryData as Position).Value;

                TurnLeft turnLeft = new TurnLeft();
                TurnRight turnRight = new TurnRight();

                throw new NotImplementedException();
            }
        }
    }
}
