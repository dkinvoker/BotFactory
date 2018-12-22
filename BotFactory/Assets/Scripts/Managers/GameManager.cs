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
        public Text GameSpeedText;

        public AudioSource GearAudioSource;

        private void Start()
        {
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Undescructable"));
        }

        public Text NotifyTextBox;

        public void Notify(string message, string playerName)
        {
            if (playerName == "Player1")
            {
                NotifyTextBox.text = message + "\n";
            }
        }

        public void OpenProgramEditor()
        {
            CameraController.IsLocked = true;
            MainCanvas.SetActive(false);
            ProgrammingCanvas.SetActive(true);
        }

        public void CloseProgramEditor()
        {
            CameraController.IsLocked = false;
            MainCanvas.SetActive(true);
            ProgrammingCanvas.SetActive(false);
        }

        public void LoadNewLvl(string name)
        {
            ClearAllPlayer1Programs();
            SceneManager.LoadScene(name, LoadSceneMode.Single);
            MainCanvas.SetActive(true);
        }

        public void ChangeGameSpeed(float newSpeedMultiplayer)
        {
            Time.timeScale = newSpeedMultiplayer;
            GameSpeedText.text = newSpeedMultiplayer.ToString("0.00");
        }

        private void ClearAllPlayer1Programs()
        {
            PlayersManager.GetPlayerByName("Player1").Programs.Clear();
        }

        public void PlayGearSound()
        {
            GearAudioSource.Play();
        }
    }
}
