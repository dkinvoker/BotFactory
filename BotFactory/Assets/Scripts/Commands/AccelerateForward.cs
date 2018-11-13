using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    class AccelerateForward : Command
    {
        public override bool Execute(Tank tank)
        {
            var body = tank.GetComponent<Rigidbody>();
            var maxSpeed = tank.Wheels.MaxSpeed;            

            if (body.velocity.magnitude < maxSpeed)
            {
                var accelerationVector = Vector3.forward * tank.Wheels.Acceleration;
                body.AddForce(accelerationVector, ForceMode.Impulse);
            }

            return true;
        }
    }
}
