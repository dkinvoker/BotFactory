using Assets.Scripts.Commands;
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
    class MemoryCommandInstanceBlock : CommandInstanceBlock
    {
        protected override void Start()
        {
            base.Start();
            FillMemoryDropDown();
        }

        private void FillMemoryDropDown()
        {
            var dropdown = this.GetComponentInChildren<Dropdown>();
            var manager = GameObject.FindGameObjectWithTag("Programming Manager");
            var memorySize = manager.GetComponent<ProgrammingManager>().MemorySize;
            List<string> options = new List<string>();
            for (int i = 0; i < memorySize; ++i)
            {
                options.Add(i.ToString());
            }
            dropdown.ClearOptions();
            dropdown.AddOptions(options);
            dropdown.onValueChanged.AddListener(DropdownValueChange);
        }

        private void DropdownValueChange(int index)
        {
            (this.Command as MemoryCommand).MemoryIndex = index;
        }
    }
}
