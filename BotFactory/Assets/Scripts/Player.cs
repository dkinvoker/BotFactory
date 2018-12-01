using Assets.Scripts.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player
    {
        public string PlayerName { get; set; }
        public string SideName { get; set; }

        public int Resources { get; set; }

        public List<List<Command>> Programs { get; private set; } = new List<List<Command>>();

        public List<GameObject> TanksBlueprints { get; private set; } = new List<GameObject>();

        public List<Tank> Tanks { get; private set; } = new List<Tank>();

        public Factory Factory { get; private set; }

        public void RegisterProgram(List<Command> program)
        {
            Programs.Add(program);
        }

        public void RegisterTankBlueprint(GameObject tank)
        {
            var tankComponent = tank.GetComponent<Tank>();
            if (tankComponent.Player != PlayerName)
            {
                throw new Exception("Blueprints player name do not match players name");
            }
            TanksBlueprints.Add(tank);
        }

        public void RegisterTank(Tank tank)
        {
            Tanks.Add(tank);
        }

        public void UnregisterTank(Tank tank)
        {
            Tanks.Remove(tank);
        }

        public void RegisterFactory(Factory factory)
        {
            if (this.Factory != null)
            {
                throw new Exception($"Player {this.PlayerName} already haves an factory registered");
            }
            this.Factory = factory;
        }
    }
}
