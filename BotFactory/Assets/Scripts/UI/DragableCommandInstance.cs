using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI
{
    class DragableCommandInstance : MonoBehaviour,
        IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private GameObject _programmingPanel;
        public GameObject ParentToReturn = null;

        public void OnBeginDrag(PointerEventData eventData)
        {
            GetComponent<CanvasGroup>().blocksRaycasts = false;

            this.transform.SetParent(this.transform.parent);
        }

        public void OnDrag(PointerEventData eventData)
        {
            this.transform.position = eventData.position;

            _programmingPanel = GameObject.FindGameObjectWithTag("Programming Panel");
            var droppingZone = _programmingPanel.GetComponent<ProgramDropZone>();

            if (droppingZone.DummySlot != null)
            {
                for (int i = 0; i < _programmingPanel.transform.childCount; ++i)
                {
                    var obj = _programmingPanel.transform.GetChild(i);
                    if (obj.transform.position.y < eventData.position.y)
                    {
                        droppingZone.DummySlot = i;
                        break;
                    }
                }
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            GetComponent<CanvasGroup>().blocksRaycasts = true;

            if (ParentToReturn == null)
            {
                Destroy(this.gameObject);
            }
            else
            {
                this.transform.SetParent(ParentToReturn.transform);
                var droppingZone = _programmingPanel.GetComponent<ProgramDropZone>();
                this.transform.SetSiblingIndex(droppingZone.DummySlot.Value);
            }
        }
    }
}
