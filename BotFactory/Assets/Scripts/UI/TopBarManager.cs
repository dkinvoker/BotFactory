using Assets.Scripts.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    class TopBarManager : MonoBehaviour
    {
        public Text ResourcesText;
        public string Player = "Player1";

        private Player _player;

        private void Start()
        {
            _player = GameObject.FindObjectOfType<PlayersManager>()[Player];
        }

        private void Update()
        {
            ResourcesText.text = _player.Resources.ToString();
        }

    }
}
