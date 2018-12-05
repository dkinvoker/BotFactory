using Assets.Scripts.Commands.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    class TurnRight : SimpleCommand
    {
        public TurnRight()
        {
        }

        public override CommandType Type
        {
            get
            {
                return CommandType.Rotation;
            }
        }

        public override string Description
        {
            get
            {
                return "Turns the tank right";
            }
        }

        public override CommandError Execute(Tank tank)
        {
            var body = tank.GetComponent<Rigidbody>();
            var transform = tank.transform;
            var speed = tank.Wheels.TurningSpeed;
            Vector3 rotationVector = new Vector3(0, speed, 0);

            transform.Rotate(rotationVector, Space.Self);
            body.velocity = Quaternion.Euler(rotationVector) * body.velocity;

            return null;
        }
    }
}
