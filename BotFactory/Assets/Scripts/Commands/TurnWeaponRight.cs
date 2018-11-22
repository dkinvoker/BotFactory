using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    [Description("Turns weapon right")]
    class TurnWeaponRight : SimpleCommand
    {
        public override CommandType Type
        {
            get
            {
                return CommandType.WeaponRotation;
            }
        }

        public override CommandError Execute(Tank tank)
        {
            var transform = tank.GetComponentsInChildren<Transform>()[2];
            var speed = 1.5f;
            Vector3 rotationVector = new Vector3(0, speed, 0);

            transform.Rotate(rotationVector, Space.World);

            return null;
        }
    }
}
