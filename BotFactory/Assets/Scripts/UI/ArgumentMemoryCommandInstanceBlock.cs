using Assets.Scripts.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    class ArgumentMemoryCommandInstanceBlock : MemoryCommandInstanceBlock
    {
        public InputField InputField;

        protected override void Start()
        {
            base.Start();
            InputField.onValueChanged.AddListener(ValueChange);
        }

        private void ValueChange(string newValue)
        {
            float value;
            if (float.TryParse(newValue, out value))
            {
                (this.Command as ArgumentMemoryCommand).Argument = value;
            }
            else
            {
                InputField.text = "0";
            }
        }
    }
}
