using Assets.Scripts.Commands;
using Assets.Scripts.Parts.Weapons;
using Assets.Scripts.Parts.Wheels;
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
    class TankConstructionManager : MonoBehaviour
    {
        public Tank Tank;
        public Weapon[] Weapons;
        public Wheels[] Wheels;

        public Dropdown WeaponDropdown;
        public Dropdown ChassisDropdown;

        private void Start()
        {
            Tank.IsLocked = true;
            PlayersManager.AddPlayer("Dummy Player", "Dummy Site");

            List<Command> program = new List<Command>();
            program.Add(new ClearMemory());

            PlayersManager.GetPlayerByName("Dummy Player").RegisterProgram(program);

            Tank.gameObject.SetActive(true);

            FillDropdowns();
        }

        private void FillWeaponsDropdown()
        {
            List<string> strings = new List<string>();
            foreach (var weapon in Weapons)
            {
                strings.Add(weapon.name);
            }
            WeaponDropdown.AddOptions(strings);
        }

        private void FillWheelsDropdown()
        {
            List<string> strings = new List<string>();
            foreach (var wheels in Wheels)
            {
                strings.Add(wheels.name);
            }
            ChassisDropdown.AddOptions(strings);
        }

        private void FillDropdowns()
        {
            FillWeaponsDropdown();
            FillWheelsDropdown();
        }

        public void WeaponDropdownValueChange(int index)
        {
            Tank.Weapon = this.Weapons[index];
            Tank.LoadWeapon();
        }

        public void ChassisDropdownValueChange(int index)
        {
            throw new NotImplementedException();
        }

        public void ChangeScene()
        {
            var tankObject = GameObject.FindGameObjectWithTag("Tank");
            tankObject.SetActive(false);
            DontDestroyOnLoad(tankObject);

            var tankScript = tankObject.GetComponent<Tank>();
            tankScript.Player = "Player1";
            tankScript.Side = "Side1";

            PlayersManager.GetPlayerByName("Player1").RegisterTankBlueprint(tankObject);
            SceneManager.LoadScene("Program Develop Scene", LoadSceneMode.Single);
        }

    }
}
