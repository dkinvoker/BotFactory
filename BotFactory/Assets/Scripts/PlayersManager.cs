using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayersManager : MonoBehaviour
    {
        #region Config
        public static int StaringResources = 100;
        #endregion

        public static List<Player> Players { get; private set; } = new List<Player>();

        public Player this[string name]
        {
            get
            {
                return Players.Single( u => u.PlayerName == name);
            }
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
            AddPlayer("Player1", "Side1");
            AddPlayer("Player2", "Side2");
        }

    }
}
