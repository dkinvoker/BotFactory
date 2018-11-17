using Assets.Scripts.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using System.ComponentModel;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    class ProgramDropZone : MonoBehaviour, 
        IDropHandler,
        IPointerEnterHandler, IPointerExitHandler
    {
        public GameObject SimpleCommandPrefab;
        public GameObject MemoryCommandPrefab;

        private GameObject _dummy = null;

        public void OnDrop(PointerEventData eventData)
        {
            var commandBlock = eventData.pointerDrag.GetComponent<CommandBlock>();
            GameObject prefabCopy = null;

            if (commandBlock.CommandBlueprint is SimpleCommand)
            {
                prefabCopy = GameObject.Instantiate(SimpleCommandPrefab, this.transform);
            }
            else if (commandBlock.CommandBlueprint is MemoryCommand)
            {
                prefabCopy = GameObject.Instantiate(MemoryCommandPrefab, this.transform);
            }

            prefabCopy.GetComponent<CommandInstanceBlock>().Command = commandBlock.CommandBlueprint.Copy();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null)
            {
                _dummy = new GameObject();

                var leyoutElement = _dummy.AddComponent<LayoutElement>();
                leyoutElement.preferredHeight = SimpleCommandPrefab.GetComponent<LayoutElement>().preferredHeight;
                leyoutElement.preferredWidth = SimpleCommandPrefab.GetComponent<LayoutElement>().preferredWidth;
                leyoutElement.flexibleHeight = 0;
                leyoutElement.flexibleWidth = 0;

                _dummy.transform.SetParent(this.transform);
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (_dummy != null)
            {
                Destroy(_dummy);
            }
        }
    }
}
