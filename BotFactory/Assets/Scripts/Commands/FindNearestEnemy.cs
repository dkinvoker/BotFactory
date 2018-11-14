using Assets.Scripts.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    class FindNearestEnemy : MemoryCommand
    {
        public FindNearestEnemy(int memoryIndex) : base(memoryIndex)
        {
        }

        public override CommandType Type
        {
            get
            {
                return CommandType.Detect;
            }
        }

        public override bool Execute(Tank tank)
        {
            var tankGameObjects = GameObject.FindGameObjectsWithTag("Tank");
            var tanks = tankGameObjects.Select(u => u.GetComponent<Tank>());
            var enemyTanks = tanks.Where(u => u.Side != tank.Side).ToArray();

            if (enemyTanks == null || enemyTanks.Length == 0)
            {
                return tank.Memory.StoreValue(null, _memoryIndex);
            }
            else
            {
                var nearestEnemy = enemyTanks[0];
                float minDistance = Vector3.Distance(nearestEnemy.transform.position, tank.transform.position);
                foreach (var enemy in enemyTanks)
                {
                    float distance = Vector3.Distance(enemy.transform.position, tank.transform.position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearestEnemy = enemy;
                    }
                }

                var variable = new Position(nearestEnemy.transform.position);
                return tank.Memory.StoreValue(variable, _memoryIndex);
            }

        }
    }
}
