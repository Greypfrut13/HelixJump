using System;
using UnityEngine;

namespace Tower.Rotation
{
    [RequireComponent(typeof(Rigidbody))]
    public class TowerRotator : MonoBehaviour
    {
        [SerializeField] [Min(0.0f)] private float _rotateSpeed;

        private Rigidbody _rigidbody;
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }
        
        public void Rotate(float direction)
        {
            float torque = -direction * _rotateSpeed;
            _rigidbody.AddTorque(Vector3.up * torque);
        }
    }
}