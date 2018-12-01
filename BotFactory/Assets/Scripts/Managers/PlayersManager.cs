using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class PlayersManager : MonoBehaviour
    {
        #region Config
        public static int StaringResources = 100;
        public static int ResourcesIncreasePerSecounds = 1;
        #endregion

        public static List<Player> Players { get; private set; } = new List<Player>();

        static PlayersManager()
        {
            AddPlayer("Player1", "Side1");
            AddPlayer("Player2", "Side2");
        }

        public Player this[string name]
        {
            get
            {
                return Players.Single( u => u.PlayerName == name);
            }
        }

        public static Player GetPlayerByName(string name)
        {
            return Players.Single(u => u.PlayerName == name);
        }

        public static void AddPlayer(string playerName, string sideName)
        {
            Player newPlayer = new Player()
            {
                PlayerName = playerName,
                SideName = sideName,
                Resources = StaringResources
            };

            Players.Add(newPlayer);
        }

        private void Start()
        {
            StartResourcesGeneration();
        }

        private void StartResourcesGeneration()
        {
            this.StartCoroutine(ResourceGeneration());
        }

        private static IEnumerator ResourceGeneration()
        {
            while (true)
            {
                yield return new WaitForSeconds(1.0f);
                foreach (var player in Players)
                {
                    player.Resources += ResourcesIncreasePerSecounds;
                }
            }  
        }
    }
}
