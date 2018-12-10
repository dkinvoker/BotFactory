using Assets.Scripts.Commands.Bases;
using Assets.Scripts.Resources;
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
    class FindNearestResource : MemoryCommand
    {
        public override CommandType Type
        {
            get
            {
                return CommandType.Detect;
            }
        }

        public override string Description
        {
            get
            {
                return "Stores location of nearest resource in specified memory cell. If there is no resources, stores null";
            }
        }

        public override CommandError Execute(Tank tank)
        {
            var resourceGameObjects = GameObject.FindGameObjectsWithTag("Resource");
            var resources = resourceGameObjects.Select(u => u.GetComponent<Resource>()).ToArray();

            if (resources == null || resources.Length == 0)
            {
                var success = tank.Memory.StoreValue(null, MemoryIndex);
                if (success)
                {
                    return null;
                }
                else
                {
                    return new CommandError($"Memory at {MemoryIndex} is full! Clear memory first");
                }
            }
            else
            {
                var nearestResource = resources[0];
                float minDistance = Vector3.Distance(nearestResource.transform.position, tank.transform.position);
                foreach (var resource in resources)
                {
                    float distance = Vector3.Distance(resource.transform.position, tank.transform.position);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        nearestResource = resource;
                    }
                }

                var variable = new Position(nearestResource.transform.position);
                var success = tank.Memory.StoreValue(variable, MemoryIndex);
                if (success)
                {
                    return null;
                }
                else
                {
                    return new CommandError($"Memory at {MemoryIndex} is full! Clear memory first");
                }
            }
        }
    }
}
