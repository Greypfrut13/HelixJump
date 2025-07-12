using Platforms;
using UnityEngine;

namespace Tower
{
    public class TowerGenerator : MonoBehaviour
    {
        [SerializeField] private Platform _startPlatform; 
        [SerializeField] private Platform _finishPlatform; 
        [SerializeField] private Platform[] _platformsVariants; 
    }
}