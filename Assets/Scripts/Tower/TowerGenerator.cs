using System;
using System.Collections.Generic;
using Extensions;
using Platforms;
using Structures;
using UnityEngine;

namespace Tower
{
    public class TowerGenerator : MonoBehaviour
    {
        [SerializeField] private TowerGeneretorSettings _generationSettings;
        
        [Header("Tower")]
        [SerializeField] private Transform _tower;

        private FloatRange RotationRange => _generationSettings.RotationRange;
        
        private void Start()
        {
            Generate(_generationSettings ,_tower);
        }

        private void Generate(TowerGeneretorSettings generationSettings, Transform tower)
        {
            List<Platform> spawnedPlatforms = SpawnPlatforms(generationSettings, out float offsetFromTop);
            FitTowerHeight(tower, offsetFromTop);
            spawnedPlatforms.ForEach(platform => platform.transform.SetParent(_tower));
        }

        private List<Platform> SpawnPlatforms(TowerGeneretorSettings generetorSettings, out float offsetFromTop)
        {
            offsetFromTop = generetorSettings.OffsetBetweenPlatforms;
            const int startAndLastPlatforms = 2;
            var spawnedPlatforms = new List<Platform>(generetorSettings.PlatformVariantsCount + startAndLastPlatforms);

            Platform startPlatform = Create(generetorSettings.StartPlatformPrefab, RotationRange, ref offsetFromTop);
            spawnedPlatforms.Add(startPlatform);
            
            for (int i = 0; i < generetorSettings.PlatformVariantsCount; i++)
            {
                Platform platform = Create(generetorSettings.PlatformVariantPrefab, RotationRange, ref offsetFromTop);
                spawnedPlatforms.Add(platform);
            }
            
            Platform finishPlatform = Create(generetorSettings.FinishPlatformPrefab, RotationRange, ref offsetFromTop);
            spawnedPlatforms.Add(finishPlatform);
            
            return spawnedPlatforms;
        }

        private Vector3 GetRandomYRotation(FloatRange rotationRange)
        {
            return Vector3.up * rotationRange.Random;
        }
        
        private Platform Create(Platform platformPrefab, FloatRange rotationRange, ref float offsetFromTop)
        {
            Platform createdPlatform = Instantiate(platformPrefab);
            
            Transform platformTransform = createdPlatform.transform;
            
            platformTransform.position = Vector3.down * offsetFromTop;
            platformTransform.eulerAngles = GetRandomYRotation(rotationRange);
            
            offsetFromTop += platformTransform.lossyScale.y + _generationSettings.OffsetBetweenPlatforms;
            
            return createdPlatform;
        }
        
        private void FitTowerHeight(Transform tower, float height)
        {
            Vector3 originalSize = tower.localScale;
            float towerHeight = height / 2.0f;
            
            tower.localScale = new Vector3(originalSize.x, towerHeight, originalSize.z);
            tower.localPosition -= Vector3.up * towerHeight;
        }
    }
}