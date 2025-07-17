using System;
using UnityEngine;

namespace Physics
{
    [Serializable]
    public class BounceData
    {
        [SerializeField] private float _maxHeight;
        [SerializeField] private float _force;

        public float MaxHeight => _maxHeight;

        public float Force => _force;
    }
}