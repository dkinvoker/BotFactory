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
        private GameObject _parentToReturn = null;

        public void OnBeginDrag(PointerEventData eventData)
        {
            GetComponent<CanvasGroup>().blocksRaycasts = false;

            this.transform.SetParent(this.transform.parent.parent);
            _programmingPanel = GameObject.FindGameObjectWithTag("Programming Panel");

            _programmingPanel.GetComponent<ProgramDropZone>().CreateDummy();
        }

        public void OnDrag(PointerEventData eventData)
        {
            this.transform.position = eventData.position;
 
            var droppingZone = _programmingPanel.GetComponent<ProgramDropZone>();

            if (droppingZone.DummySlot != null)
            {
                _parentToReturn = _programmingPanel;
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
            else
            {
                this._parentToReturn = null;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            GetComponent<CanvasGroup>().blocksRaycasts = true;

            if (_parentToReturn == null)
            {
                Destroy(this.gameObject);
            }
            else
            {
                this.transform.SetParent(_parentToReturn.transform);
                var droppingZone = _programmingPanel.GetComponent<ProgramDropZone>();
                this.transform.SetSiblingIndex(droppingZone.DummySlot.Value);
                droppingZone.DestroyDummy();
            }
        }
    }
}
