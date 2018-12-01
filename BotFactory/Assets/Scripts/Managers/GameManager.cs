using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static void SpawnTankAtLocation(GameObject blueprint, Vector3 location)
        {
            var copy = GameObject.Instantiate(blueprint);
            copy.transform.position = location;
            copy.transform.localScale = new Vector3(1, 1, 1);
            copy.SetActive(true);
        }

        private void Start()
        {
            var playersTank = PlayersManager.GetPlayerByName("Player1").TanksBlueprints[0];
            SpawnTankAtLocation(playersTank, new Vector3(0, 0, 0));
        }
    }
}
