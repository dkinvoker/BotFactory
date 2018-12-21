using Assets.Scripts.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            var lvlManager = GameObject.FindObjectOfType<LvlManager>();

            if (lvlManager != null)
            {
                lvlManager.ResourcesRequied--;
                if (lvlManager.ResourcesRequied == 0 && lvlManager.TimeToDestroy == false)
                {
                    var undescructable = GameObject.FindGameObjectWithTag("Undescructable");
                    if (undescructable != null)
                    {
                        SceneManager.MoveGameObjectToScene(undescructable, SceneManager.GetActiveScene());
                    }
                    SceneManager.LoadScene("Menu");
                }
            }

        }


    }
}
