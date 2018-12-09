using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public GameObject MainCanvas;
        public GameObject ProgrammingCanvas;

        private void Start()
        {
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Undescructable"));
        }

        //public Text NotifyTextBox;

        //public void Notify(string message, string playerName)
        //{
        //    if (playerName == MainPlayerName)
        //    {
        //        NotifyTextBox.text += message + "\n";
        //    } 
        //}

        public void OpenProgramEditor()
        {
            MainCanvas.SetActive(false);
            ProgrammingCanvas.SetActive(true);
        }

        public void CloseProgramEditor()
        {
            MainCanvas.SetActive(true);
            ProgrammingCanvas.SetActive(false);
        }

        public void LoadLvl(string name)
        {
            SceneManager.LoadScene(name, LoadSceneMode.Single);
            MainCanvas.SetActive(true);
        }
    }
}
