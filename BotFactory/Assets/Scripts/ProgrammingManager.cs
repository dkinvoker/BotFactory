using Assets.Scripts.Commands;
using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    class ProgrammingManager : MonoBehaviour
    {
        public GameObject CommandPrefab;
        private readonly Command[] _allCommands = 
        {
            new AccelerateForward(),
            new ClearMemory(),
            new DeleteMemoryAt(),
            new FindNearestEnemy(),
            new Fire(),
            new Jump(),
            new JumpIfAimingEnemy(),
            new JumpIfFacingEnemy(),
            new JumpIfWeaponReady(),
            new TurnLeft(),
            new TurnRight(),
            new TurnToPosition(),
            new TurnWeaponLeft(),
            new TurnWeaponRight(),
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

        public void ChangeScene()
        {
            SaveProgram("Player1");
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
        }

        private void SaveProgram(string player)
        {
            var programmingPanel = GameObject.FindGameObjectWithTag("Programming Panel");
            var blocks = programmingPanel.transform.GetComponentsInChildren<CommandInstanceBlock>();
            var program = blocks.Select( u => u.Command ).ToList();
            ProgramController.RegisterProgram(player, program);
        }
    }
}
