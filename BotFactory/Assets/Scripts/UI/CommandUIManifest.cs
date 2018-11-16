using Assets.Scripts.Commands;
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
    [CreateAssetMenu(fileName = "CommandUIManifest", menuName = "Custiom UI/Command UI Manifest")]
    class CommandUIManifest : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [TextArea]
        public string Description = "Command Description";
        public Command CommandBlueprint = null;

        public void OnPointerEnter(PointerEventData eventData)
        {
            GameObject.FindGameObjectWithTag("Info Box").GetComponent<Text>().text = Description;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            GameObject.FindGameObjectWithTag("Info Box").GetComponent<Text>().text = string.Empty;
        }
    }
}
