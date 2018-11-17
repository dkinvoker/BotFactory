using Assets.Scripts.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    class CommandInstanceBlock : MonoBehaviour
    {
        public Command Command { get; set; }

        private void Start()
        {
            this.GetComponentInChildren<Text>().text = Command.GetType().Name;
        }

    }
}
