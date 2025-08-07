using Platforms;
using UnityEngine;

namespace Tower
{
    public class TowerGenerator : MonoBehaviour
    {
        [SerializeField] [Min(0)] private int _platformsCount;
        [SerializeField] [Min(0.0f)] private float _spawnStep;
        
        [SerializeField] private TowerGenerationData _data;

        private const float START_PLATFORM_OFFSET = 0.5f;

        private void Start()
        {
            Generate(_data.TowerBase);
        }

        private void Generate(GameObject towerBasePrefab)
        {
            GameObject towerBase = Instantiate(towerBasePrefab, transform);
            towerBase.transform.localScale = new Vector3(1f, _platformsCount / 2f + _spawnStep, 1f);
            
            Vector3 spawnPosition = towerBase.transform.position;
            spawnPosition.y += towerBase.transform.localScale.y - START_PLATFORM_OFFSET;

            SpawnPlatform(_data.StartPlatform, ref spawnPosition, transform);

            for (int i = 0; i < _platformsCount; i++)
            {
                SpawnPlatform(_data.GetRandomPlatform(), ref spawnPosition, transform);
            }
            
            SpawnPlatform(_data.FinishPlatform, ref spawnPosition, transform);
        }

        private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Transform parent)
        {
            Quaternion randomYRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            
            Platform createdPlatform = Instantiate(platform, spawnPosition, randomYRotation, parent);

            spawnPosition.y -= _spawnStep;
        }
    }
}