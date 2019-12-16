using System;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace View.Common
{
    public class EventTriggerListener : EventTrigger
    {
        public Action<GameObject> OnClickCallback;
        public ScrollRect ScrollRect { get; private set; }

        public bool IsDragging { get; private set; }
        public event Action<GameObject> OnClick;

        public static EventTriggerListener Get(Transform transform)
        {
            var listener = transform.GetComponent<EventTriggerListener>();
            if (listener == null) listener = transform.gameObject.AddComponent<EventTriggerListener>();

            if (listener.ScrollRect == null)
                listener.ScrollRect = transform.gameObject.GetComponentsInParent<ScrollRect>(true).FirstOrDefault();

            return listener;
        }

        public static EventTriggerListener Get(GameObject go)
        {
            return Get(go.transform);
        }

        private void Awake()
        {
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);

            if (IsDragging) return;

            OnClick?.Invoke(gameObject);
            OnClickCallback?.Invoke(gameObject);
        }

        public override void OnBeginDrag(PointerEventData eventData)
        {
            IsDragging = true;
            //Debug.Assert(ScrollRect != null, "ScrollRect == null");

            if (ScrollRect == null) return;
            ScrollRect.OnBeginDrag(eventData);
        }

        public override void OnDrag(PointerEventData eventData)
        {
            IsDragging = true;

            if (ScrollRect == null) return;

            ScrollRect.OnDrag(eventData);
        }

        public override void OnEndDrag(PointerEventData eventData)
        {
            IsDragging = false;

            if (ScrollRect == null) return;
            ScrollRect.OnEndDrag(eventData);
        }
    }
}