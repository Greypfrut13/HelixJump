using Extensions;
using Platforms;
using Structures;
using UnityEngine;

namespace Tower
{
    [CreateAssetMenu(fileName = "TowerGeneretorSettings", menuName = "ScriptableObjects/Tower/TowerGeneretorSettings")]
    public class TowerGeneretorSettings : ScriptableObject
    {
        [SerializeField] [Min(0)] private int _platformVariantsCount;
        [SerializeField] [Min(0.0f)] private float _offsetBetweenPlatforms;

        [SerializeField] private FloatRange _rotationRange;
        
        [Header("Platform Prefabs")]
        [SerializeField] private Platform _startPlatformPrefab; 
        [SerializeField] private Platform _finishPlatformPrefab; 
        [SerializeField] private Platform[] _platformsVariantsPrefabs;

        public int PlatformVariantsCount => _platformVariantsCount;

        public float OffsetBetweenPlatforms => _offsetBetweenPlatforms;

        public Platform StartPlatformPrefab => _startPlatformPrefab;

        public Platform FinishPlatformPrefab => _finishPlatformPrefab;

        public Platform PlatformVariantPrefab => _platformsVariantsPrefabs.Random();

        public FloatRange RotationRange => _rotationRange;
    }
}