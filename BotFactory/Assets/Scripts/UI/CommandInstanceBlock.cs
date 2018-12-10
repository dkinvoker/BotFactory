using Assets.Scripts.Commands;
using Assets.Scripts.Commands.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    class CommandInstanceBlock : MonoBehaviour
    {
        public Command Command { get; set; }
        private GameObject _programmingPanel;

        protected virtual void Start()
        {
            this.GetComponentInChildren<Text>().text = Command.GetType().Name;
        }

    }
}
