using Assets.Scripts.Commands;
using Assets.Scripts.Parts.Weapons;
using Assets.Scripts.Parts.Wheels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
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

        private void FillDropdowns()
        {
            FillWeaponsDropdown();
        }

    }
}
