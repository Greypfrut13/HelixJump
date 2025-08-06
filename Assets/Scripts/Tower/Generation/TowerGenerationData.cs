using System;
using Platforms;
using UnityEngine;

namespace Tower
{
    [Serializable]
    public class TowerGenerationData
    {
        [SerializeField] private GameObject _towerBase;
        
        [Header("Platforms")]
        [SerializeField] private Platform _startPlatform;
        [SerializeField] private Platform _finishPlatform;
        [SerializeField] private Platform[] _platformPrefabs;

        public GameObject TowerBase => _towerBase;

        public Platform StartPlatform => _startPlatform;

        public Platform FinishPlatform => _finishPlatform;

        public Platform[] PlatformPrefabs => _platformPrefabs;

        public Platform GetRandomPlatform()
        {
            int randomIndex = UnityEngine.Random.Range(0, _platformPrefabs.Length);
            
            return _platformPrefabs[randomIndex];
        }
    }
}