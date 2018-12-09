using Assets.Scripts.Bases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Factory : Unit
    {
        public Transform SpawnPoint;
        public bool IsLocked { get; private set; }

        
        public void ConstructTank(int index)
        {
            if (IsLocked)
            {
                //GameObject.FindObjectOfType<GameManager>().Notify("Factory Is occupied!", this.Player);
            }
            else
            {
                var player = PlayersManager.GetPlayerByName(this.Player);
                var gameObjectBlueprint = player.TanksBlueprints[index];
                var tankScript = gameObjectBlueprint.GetComponent<Tank>();

                var cost = tankScript.CalculateCost();
                var time = tankScript.CalculateSpawningTime();

                if (player.Resources < cost)
                {
                    //GameObject.FindObjectOfType<GameManager>().Notify("No enough minerals!", this.Player);
                    return;
                }
                else
                {
                    player.Resources -= cost;
                    StartCoroutine(BeginConstruction(tankScript, time));
                    return;
                }
            }
        }

        private IEnumerator BeginConstruction(Tank blueprint, float time)
        {
            this.IsLocked = true;
            yield return new WaitForSeconds(time);
            this.IsLocked = false;
            //GameObject.FindObjectOfType<GameManager>().Notify("Tank Constructed!", this.Player);
            SpawnTank(blueprint.gameObject);
        }

        private Tank SpawnTank(GameObject blueprint)
        {
            var copy = Instantiate(blueprint);
            copy.transform.position = SpawnPoint.position;
            copy.transform.localScale = new Vector3(1, 1, 1);
            copy.SetActive(true);
            return copy.GetComponent<Tank>();
        }

        private void Start()
        {
            this.HP = 1000;
            PlayersManager.GetPlayerByName(this.Player).RegisterFactory(this);
        }

        private void Update()
        {
            CheckHP();
        }
    }
}
