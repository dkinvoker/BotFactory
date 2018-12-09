using Assets.Scripts.Commands;
using Assets.Scripts.Commands.Bases;
using Assets.Scripts.Commands.Unique;
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
        public GameObject CommandsPanel;
        private readonly Command[] _allCommands =
        {
            new AccelerateForward(),
            new AddTurningSpeed(),
            new ArithmeticalComparison(),
            new Break(),
            new ClearMemory(),
            new Decrement(),
            new DeleteMemoryAt(),
            new FindNearestEnemyTank(),
            new FindNearestResource(),
            new Fire(),
            new Increment(),
            new Jump(),
            new JumpIfAimingEnemyTank(),
            new JumpIfCloseToColision(),
            new JumpIfFacingEnemyTank(),
            new JumpIfPositionInRange(),
            new JumpIfWeaponReady(),
            new Store0(),
            new StoreValue(),
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
            foreach (var command in _allCommands)
            {
                var newCommandBlock = GameObject.Instantiate(CommandPrefab, CommandsPanel.transform);
                newCommandBlock.GetComponent<CommandBlock>().CommandBlueprint = command;
            }   
        }

        public void Confirm()
        {
            SaveProgram("Player1");
            GameObject.FindObjectOfType<GameManager>().CloseProgramEditor();
            ReloadScene();
            PlayersManager.GetPlayerByName("Player1").LoadProgramInAllTanks(0);
        }

        private void SaveProgram(string player)
        {
            var programmingPanel = GameObject.FindGameObjectWithTag("Programming Panel");
            var blocks = programmingPanel.transform.GetComponentsInChildren<CommandInstanceBlock>();
            var childCount = programmingPanel.transform.childCount;

            //Decoding Target Blocks To Jump Indexes
            foreach (var block in blocks)
            {
                if (block is JumpCommandInstanceBlock)
                {
                    var jumpTarget = (block as JumpCommandInstanceBlock).TargetBlock;
                    int consideringJumpIndex = jumpTarget.transform.GetSiblingIndex();
                    while (true)
                    {
                        if (consideringJumpIndex == childCount - 1)
                        {
                            consideringJumpIndex = 0;
                        }
                        else
                        {
                            consideringJumpIndex++;
                        }

                        var commandBlock = programmingPanel.transform.GetChild(consideringJumpIndex).GetComponent<CommandInstanceBlock>();
                        if (commandBlock != null)
                        {
                            var command = (block as JumpCommandInstanceBlock).Command;
                            (command as JumpCommand).JumpPosition = blocks.ToList().IndexOf(commandBlock);
                            break;
                        }
                    }
                }
            }

            var program = blocks.Select(u => u.Command).ToList();
            PlayersManager.GetPlayerByName(player).SaveProgramAtLocationOrAddAtTheEnd(program, 0);
        }

        private void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
