using Assets.Scripts.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class TankConstructionManager : MonoBehaviour
    {
        public Tank Tank;

        private void Start()
        {
            Tank.IsLocked = true;
            PlayersManager.AddPlayer("Dummy Player", "Dummy Site");

            List<Command> program = new List<Command>();
            program.Add(new ClearMemory());

            PlayersManager.GetPlayerByName("Dummy Player").RegisterProgram(program);

            Tank.gameObject.SetActive(true);
        }

    }
}
