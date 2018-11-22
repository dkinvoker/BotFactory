﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Commands
{
    [Description("Redirect program flow to specific command number if weapon is ready to fire")]
    class JumpIfWeaponReady : JumpCommand
    {
        public override CommandError Execute(Tank tank)
        {
            var shouldJump = false;

            if (tank.IsReadyToFire)
            {
                shouldJump = true;
            }

            if (Negate)
            {
                shouldJump = !shouldJump;
            }

            if(shouldJump)
            {
                new Jump() { JumpPosition = this.JumpPosition }.Execute(tank);
            }
            
            return null;
        }
    }
}
