using Assets.Scripts.Variables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    [Description("Turns the tank left or right dependig on the position stored in memory cell")]
    class TurnToPosition : MemoryCommand
    {

        public override CommandType Type
        {
            get
            {
                return CommandType.Rotation;
            }
        }

        public override CommandError Execute(Tank tank)
        {
            var memoryData = tank.Memory[MemoryIndex];
            if (memoryData == null)
            {
                return new CommandError("Memory at" + MemoryIndex + " is empty");
            }
            else if ( !(memoryData is Position) )
            {
                return new CommandError("Memory at" + MemoryIndex + " is not a Position type");
            }
            else
            {
                var yourPosition = tank.transform.position;
                var enemyPosition = (memoryData as Position).Value;

                var targetDirection = enemyPosition - yourPosition;

                float angleDirection = Vector3.SignedAngle(tank.transform.forward, targetDirection, new Vector3(0, 90, 0));

                //If you want you can check if angle is == 0, and abort rotation

                if (angleDirection > 0)
                {
                    new TurnRight().Execute(tank);
                }
                else
                {
                    new TurnLeft().Execute(tank);
                }
                
                return null;
            }
        }
    }
}
