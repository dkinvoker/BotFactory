using Assets.Scripts.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.UI
{
    class ProgrammingManager : MonoBehaviour
    {
        public GameObject CommandPrefab;
        private readonly Command[] _allCommands = 
        {
            new AccelerateForward(),
            new DeleteMemoryAt(),
            new FindNearestEnemy(),
            new TurnLeft(),
            new TurnRight(),
            new TurnToPosition(),
            new TurnWeaponToPosition()
        };

        public int MemorySize { get; set; } = 3;

        private void Start()
        {
            var panel = GameObject.FindGameObjectWithTag("Available Commands Area");
            foreach (var command in _allCommands)
            {
                var newCommandBlock = GameObject.Instantiate(CommandPrefab, panel.transform);
                newCommandBlock.GetComponent<CommandBlock>().CommandBlueprint = command;
            }   
        }


    }
}
