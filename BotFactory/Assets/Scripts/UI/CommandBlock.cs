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
    class CommandBlock : MonoBehaviour, 
        IPointerEnterHandler, IPointerExitHandler, 
        IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public Command CommandBlueprint { get; set; }
        private CommandBlock _copy = null;


        private void Start()
        {
            this.GetComponentInChildren<Text>().text = CommandBlueprint.GetType().Name;
        }

        #region On pointer
        public void OnPointerEnter(PointerEventData eventData)
        {
            GameObject.FindGameObjectWithTag("Info Box").GetComponent<Text>().text = CommandBlueprint.Description;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            GameObject.FindGameObjectWithTag("Info Box").GetComponent<Text>().text = string.Empty;
        }
        #endregion


        #region On Drag
        public void OnBeginDrag(PointerEventData eventData)
        {
            GetComponent<CanvasGroup>().blocksRaycasts = false;

            _copy = GameObject.Instantiate<CommandBlock>(this, this.transform.parent.parent);

            _copy.CommandBlueprint = this.CommandBlueprint;

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
        #endregion
    }
}
