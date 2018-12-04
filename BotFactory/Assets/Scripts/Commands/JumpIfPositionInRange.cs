using Assets.Scripts.Variables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    class JumpIfPositionInRange : MemoryJumpCommand
    {
        public override string Description
        {
            get
            {
                return "Jumps to certain location if specific position stored in specyfic memory location is in weapon range";
            }
        }

        protected override bool DirectConditionCheck(Tank tank)
        {
            var memoryData = (tank.Memory[MemoryIndex] as Position).Value;
            var tankPosition = tank.transform.position;

            if (Vector3.Distance(memoryData, tankPosition) <= tank.Weapon.Range * 0.9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override bool IsVariableGoodType(Tank tank)
        {
            var memoryData = tank.Memory[MemoryIndex];
            if (memoryData is Position)
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
