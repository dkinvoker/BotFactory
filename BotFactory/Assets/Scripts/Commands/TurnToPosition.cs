using Assets.Scripts.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Commands
{
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

        public override bool Execute(Tank tank)
        {
            var memoryData = tank.Memory[_memoryIndex];
            if (memoryData == null)
            {
                return false;
            }
            else if ( !(memoryData is Position) )
            {
                return false;
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
