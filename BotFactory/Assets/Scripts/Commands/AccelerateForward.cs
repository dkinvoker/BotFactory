using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    [Description("Accelerates the tank in facing direction")]
    class AccelerateForward : SimpleCommand
    {
        public override CommandType Type
        {
            get
            {
                return CommandType.Move;
            }
        }

        public override CommandError Execute(Tank tank)
        {
            var body = tank.GetComponent<Rigidbody>();
            var maxSpeed = tank.Wheels.MaxSpeed;            

            if (body.velocity.magnitude < maxSpeed)
            {
                var accelerationVector = Vector3.forward * tank.Wheels.Acceleration;
                body.AddRelativeForce(accelerationVector);
            }

            return null;
        }
    }
}
