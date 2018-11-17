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
    class ProgramDropZone : MonoBehaviour, IDropHandler
    {
        public GameObject SimpleCommandPrefab;
        public GameObject MemoryCommandPrefab;

        public void OnDrop(PointerEventData eventData)
        {
            var commandManifest = eventData.pointerDrag.GetComponent<CommandBlock>();
            if (commandManifest.CommandBlueprint is SimpleCommand)
            {
                var copy = GameObject.Instantiate(SimpleCommandPrefab, this.transform);
                CopyComandInfo(copy, commandManifest);
            }
            else if (commandManifest.CommandBlueprint is MemoryCommand)
            {
                var copy = GameObject.Instantiate(MemoryCommandPrefab, this.transform);
                CopyComandInfo(copy, commandManifest);
            }
        }

        private void CopyComandInfo(GameObject copy, CommandBlock commandManifest)
        {
            //copy.AddComponent<CommandStorageComponent>();
            //copy.GetComponent<CommandStorageComponent>().Command = commandManifest.CommandBlueprint;
            //copy.transform.GetComponentInChildren<Text>().text = commandManifest.gameObject.name;
        }
    }
}
