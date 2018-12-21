using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Resources
{
    class Resource : MonoBehaviour
    {
        public int ResourcesCount = 50;

        private Vector3 _rotVector = new Vector3(16f, 32f, 48f); 

        private void Update()
        {
            this.transform.Rotate(_rotVector * Time.deltaTime, Space.Self);
        }

        private void OnTriggerEnter(Collider other)
        {
            var tank = other.GetComponent<Tank>();
            var playerName = tank.Player;

            PlayersManager.GetPlayerByName(playerName).Resources += this.ResourcesCount;

            Destroy(this.gameObject);
        }

        private void OnDestroy()
        {
            GameObject.FindObjectOfType<GameManager>()?.PlayGearSound();
        }


    }
}
