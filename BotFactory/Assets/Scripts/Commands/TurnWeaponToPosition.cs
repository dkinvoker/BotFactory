﻿using Assets.Scripts.Commands.Bases;
using Assets.Scripts.Variables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    class TurnWeaponToPosition : MemoryCommand
    {
        public override CommandType Type
        {
            get
            {
                return CommandType.WeaponRotation;
            }
        }

        public override string Description
        {
            get
            {
                return "Turns the tank weapon left or right dependig on the position stored in memory cell";
            }
        }

        public override CommandError Execute(Tank tank)
        {
            var memoryData = tank.Memory[MemoryIndex];
            if (memoryData == null)
            {
                return new CommandError("Memory at" + MemoryIndex + " is empty");
            }
            else if (!(memoryData is Position))
            {
                return new CommandError("Memory at" + MemoryIndex + " is not a Position type");
            }
            else
            {
                var yourPosition = tank.transform.position;
                var enemyPosition = (memoryData as Position).Value;

                var weaponFacingAngle = -tank.GetComponentsInChildren<Transform>()[2].right;

                var targetDirection = enemyPosition - yourPosition;

                float angleDirection = Vector3.SignedAngle(weaponFacingAngle, targetDirection, new Vector3(0, 90, 0));

                //If you want you can check if angle is == 0, and abort rotation

                if (angleDirection > 0)
                {
                    new TurnWeaponRight().Execute(tank);
                }
                else
                {
                    new TurnWeaponLeft().Execute(tank);
                }

                return null;
            }
        }
    }
}
