using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Input
{
    public class InputSwipePanel : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public event Action<Swipe> SwipeBegan;
        public event Action<Swipe> Swiping;
        public event Action<Swipe> SwipingEnded;
        
        private Vector2 _startPosition;
        
        public void OnBeginDrag(PointerEventData eventData)
        {
            _startPosition = eventData.position;
            
            Invoke(SwipeBegan, eventData);
        }

        public void OnDrag(PointerEventData eventData)
        {
            Invoke(Swiping, eventData);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Invoke(SwipingEnded, eventData);
        }

        private void Invoke(Action<Swipe> action, PointerEventData eventData)
        {
            action?.Invoke(CreateSwipeFrom(_startPosition, eventData));
        }
        
        private Swipe CreateSwipeFrom(Vector2 startPosition, PointerEventData eventData)
        {
            return new Swipe(startPosition, eventData.position, eventData.delta);
        }
    }
}