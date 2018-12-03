using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    class JumpIfCloseToColision : JumpCommand
    {
        protected override bool DirectConditionCheck(Tank tank)
        {
            bool shouldJump = false;
            const float maxDistance = 0.5f;

            var raycastHit = Physics.Raycast(tank.transform.position + new Vector3(0, 0.2f, 0), tank.transform.forward, maxDistance);
            if (raycastHit)
            {
                shouldJump = true;
            }

            return shouldJump;
        }
    }
}
