using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Managers
{
    class LvlManager : MonoBehaviour
    {
        public int ResourcesRequied = 1;

        private void Update()
        {
            if (ResourcesRequied == 0)
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
