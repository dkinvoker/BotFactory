using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public Text NotifyTextBox;
        public string MainPlayerName = "Player1";

        public static void SpawnTankAtLocation(GameObject blueprint, Vector3 location)
        {
            var copy = GameObject.Instantiate(blueprint);
            copy.transform.position = location;
            copy.transform.localScale = new Vector3(1, 1, 1);
            copy.SetActive(true);
        }

        public void Notify(string message, string playerName)
        {
            if (playerName == MainPlayerName)
            {
                NotifyTextBox.text += message + "\n";
            } 
        }

        private void Start()
        {
            var playersTank = PlayersManager.GetPlayerByName("Player1").TanksBlueprints[0];
            SpawnTankAtLocation(playersTank, new Vector3(0, 0, 0));
        }

        private void Update()
        {

            if (Input.GetKeyDown("1"))
            {
                OrderFactoryBuildingTank(0);
            }
            if (Input.GetKeyDown("2"))
            {
                OrderFactoryBuildingTank(1);
            }
            if (Input.GetKeyDown("3"))
            {
                OrderFactoryBuildingTank(2);
            }
        }

        public void OrderFactoryBuildingTank(int index)
        {
            PlayersManager.GetPlayerByName("Player1").Factory.ConstructTank(index);
        }
    }
}
