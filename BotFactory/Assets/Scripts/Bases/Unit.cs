using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Bases
{
    public class Unit : MonoBehaviour
    {
        public int HP { get; set; }
        public string Player;

        public string Side
        {
            get
            {
                return PlayersManager.GetPlayerByName(this.Player).SideName;
            }
        }

        protected void CheckHP()
        {
            if (HP <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
