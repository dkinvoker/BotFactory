using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    [Description("Redirect program flow to specific command number, if the tank is directly facing enemy tank")]
    class JumpIfFacingEnemy : JumpCommand
    {
        public override CommandError Execute(Tank tank)
        {
            var reycastedObjects = Physics.RaycastAll(tank.transform.position + new Vector3(0, 0.2f, 0), tank.transform.forward);
            if (reycastedObjects.Length > 0)
            {
                var firstHitObject = reycastedObjects[0];
                if (firstHitObject.transform.gameObject.GetComponent<Tank>() != null)
                {
                    return new Jump() { JumpPosition = this.JumpPosition}.Execute(tank);
                }
            }
            return null;
        }
    }
}
