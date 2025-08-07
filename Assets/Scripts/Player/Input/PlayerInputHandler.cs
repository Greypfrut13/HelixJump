using System;
using Tower.Rotation;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Player.Input
{
    public class PlayerInputHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        [SerializeField] private TowerRotator _towerRotator;

        [SerializeField] [Min(0.0f)] private float _maxSensitivity;
        
        private Vector3 _startPosition;
        private float _rotationDirection;
        
        private void Update()
        {
            _towerRotator.Rotate(_rotationDirection);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _startPosition = eventData.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            _rotationDirection = CalculateRotationDirection(eventData);
        }
        
        public void OnEndDrag(PointerEventData eventData)
        {
            _rotationDirection = 0;
        }

        private float CalculateRotationDirection(PointerEventData eventData)
        {
            Vector3 currentPosition = eventData.position;
            float deltaX = currentPosition.x - _startPosition.x;

            float direction = MathF.Sign(deltaX);
            float rotationStrength = MathF.Min(MathF.Abs(deltaX) / _maxSensitivity, 1f);
            
            return rotationStrength * direction;
        }

        
    }
}