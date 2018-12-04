using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    class JumpIfCloseToColision : JumpCommand
    {
        public override string Description
        {
            get
            {
                return "Jumps to specyfic program location if tank is facing object in close distance";
            }
        }

        protected override bool DirectConditionCheck(Tank tank)
        {
            const float maxDistance = 20f;

            //---
            Debug.DrawRay(tank.transform.position + new Vector3(0, 0.2f, 0), tank.transform.forward, Color.green, 20, true);
            //---

            var raycastHit = Physics.Raycast(tank.transform.position + new Vector3(0, 0.2f, 0), tank.transform.forward, maxDistance);
            if (raycastHit)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
