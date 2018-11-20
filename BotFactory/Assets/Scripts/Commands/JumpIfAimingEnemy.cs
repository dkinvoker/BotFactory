using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    [Description("Redirect program flow to specific command number, if your weapon is aiming enemy")]
    class JumpIfAimingEnemy : JumpCommand
    {
        public override CommandError Execute(Tank tank)
        {
            var directionalVector = tank.FirePoint.transform.forward;
            var reycastedObjects = Physics.RaycastAll(tank.transform.position + new Vector3(0, 0.2f, 0), directionalVector);
            if (reycastedObjects.Length > 0)
            {
                var firstHitObject = reycastedObjects[0];
                if (firstHitObject.transform.gameObject.GetComponent<Tank>() != null)
                {
                    return new Jump() { JumpPosition = this.JumpPosition }.Execute(tank);
                }
            }
            return null;
        }
    }
}
