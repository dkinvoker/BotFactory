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
using static UnityEngine.UI.Dropdown;

namespace Assets.Scripts.UI
{
    class ProgramDropZone : MonoBehaviour, 
        IDropHandler,
        IPointerEnterHandler, IPointerExitHandler
    {
        public GameObject SimpleCommandPrefab;
        public GameObject MemoryCommandPrefab;
        public GameObject JumpCommandPrefab;

        public GameObject JumpTargetPrefab;

        public int? DummySlot
        {
            get
            {
                return _dummy?.transform.GetSiblingIndex();
            }
            set
            {
                if (_dummy != null)
                {
                    _dummy.transform.SetSiblingIndex(value.Value);
                }
            }
        }

        private GameObject _dummy = null;

        private void Start()
        {  
        }

        public void OnDrop(PointerEventData eventData)
        {
            var commandBlock = eventData.pointerDrag.GetComponent<CommandBlock>();

            if (commandBlock == null)
            {
                return;
            }

            GameObject prefabCopy = null;

            if (commandBlock.CommandBlueprint is SimpleCommand)
            {
                prefabCopy = GameObject.Instantiate(SimpleCommandPrefab, this.transform);
            }
            else if (commandBlock.CommandBlueprint is MemoryCommand)
            {
                prefabCopy = GameObject.Instantiate(MemoryCommandPrefab, this.transform);
            }
            else if (commandBlock.CommandBlueprint is JumpCommand)
            {
                prefabCopy = GameObject.Instantiate(JumpCommandPrefab, this.transform);
                var targetBlockCopy = GameObject.Instantiate(JumpTargetPrefab, this.transform);

                Color jumpColor = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
                prefabCopy.GetComponent<Image>().color = jumpColor;
                targetBlockCopy.GetComponent<Image>().color = jumpColor;

                prefabCopy.GetComponent<JumpCommandInstanceBlock>().TargetBlock = targetBlockCopy;
                targetBlockCopy.GetComponent<JumpTarget>().JumpParent = prefabCopy;
            }

            prefabCopy.transform.SetSiblingIndex(DummySlot.Value);
            prefabCopy.GetComponent<CommandInstanceBlock>().Command = commandBlock.CommandBlueprint.Copy();

            DestroyDummy();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null)
            {
                CreateDummy();
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            DestroyDummy();
        }

        public void DestroyDummy()
        {
            if (_dummy != null)
            {
                Destroy(_dummy);
                _dummy = null;
            }
        }

        public void CreateDummy()
        {
            DestroyDummy();

            _dummy = new GameObject();

            var leyoutElement = _dummy.AddComponent<LayoutElement>();
            leyoutElement.preferredHeight = SimpleCommandPrefab.GetComponent<LayoutElement>().preferredHeight;
            leyoutElement.preferredWidth = SimpleCommandPrefab.GetComponent<LayoutElement>().preferredWidth;
            leyoutElement.flexibleHeight = 0;
            leyoutElement.flexibleWidth = 0;

            _dummy.transform.SetParent(this.transform);
            _dummy.transform.SetSiblingIndex(DummySlot.Value);
        }

    }
}
