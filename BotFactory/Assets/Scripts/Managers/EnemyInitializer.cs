using Assets.Scripts.Commands;
using Assets.Scripts.Commands.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    class EnemyInitializer : MonoBehaviour
    {

        private void Start()
        {
            List<Command> program2 = new List<Command>();
            program2.Add(new JumpIfAimingEnemyTank() { Negate = true, JumpPosition = 0 });
            program2.Add(new JumpIfWeaponReady() { Negate = true, JumpPosition = 0});
            program2.Add(new Fire());

            //PlayersManager.AddPlayer("Player2", "Side2");
            PlayersManager.GetPlayerByName("Player2").SaveProgramAtLocationOrAddAtTheEnd(program2, 2);
        }

    }
}
