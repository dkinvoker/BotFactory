﻿using Assets.Scripts.Commands.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    class JumpIfAimingEnemyTank : JumpCommand
    {
        public override string Description
        {
            get
            {
                return "Redirect program flow to specific command number, if your weapon is aiming enemy";
            }
        }

        protected override bool DirectConditionCheck(Tank tank)
        {
            bool shouldJump = false;

            var directionalVector = tank.FirePoint.transform.forward;
            var reycastedObjects = Physics.RaycastAll(tank.transform.position + new Vector3(0, 0.2f, 0), directionalVector);
            if (reycastedObjects.Length > 0)
            {
                var firstHitObject = reycastedObjects.Last();
                var scriptComponent = firstHitObject.transform.gameObject.GetComponent<Tank>();
                if (scriptComponent != null)
                {
                    if (scriptComponent.Side != tank.Side)
                    {
                        shouldJump = true;
                    }
                }
            }

            return shouldJump;
        }
    }
}
