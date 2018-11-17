using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    [Description("Turns the tank left")]
    class TurnLeft : SimpleCommand
    {
        public TurnLeft()
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
            var body = tank.GetComponent<Rigidbody>();
            var speed = tank.Wheels.TurningSpeed;

            if (body.angularVelocity.y < speed)
            {
                body.AddTorque(Vector3.down * speed, ForceMode.Impulse);
            }

            return null;
        }
    }
}
