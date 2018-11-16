using Assets.Scripts.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI
{
    class CommandManifestDragger : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private CommandManifestDragger _copy = null; 

        public void OnBeginDrag(PointerEventData eventData)
        {
            GetComponent<CanvasGroup>().blocksRaycasts = false;

            _copy = GameObject.Instantiate<CommandManifestDragger>(this, this.transform.parent.parent);

            var height = this.GetComponent<RectTransform>().rect.height;
            var width = this.GetComponent<RectTransform>().rect.width;
            _copy.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
            _copy.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        }

        public void OnDrag(PointerEventData eventData)
        {
            _copy.transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Destroy(_copy.gameObject);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }

    }
}
