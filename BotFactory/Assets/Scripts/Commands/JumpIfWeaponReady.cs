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
        protected override bool DirectConditionCheck(Tank tank)
        {
            if (tank.IsReadyToFire)
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
