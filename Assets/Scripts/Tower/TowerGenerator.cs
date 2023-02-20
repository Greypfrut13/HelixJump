using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGenerator : MonoBehaviour
{ 
    [SerializeField] TowerGenerationSettings _towerGenerationSettings;

    [Header("Tower")]
    [SerializeField] private Transform _tower;

    private FloatRange RotationRange => _towerGenerationSettings.RotationRange;

    private void Start() 
    {
        Generate(_towerGenerationSettings, _tower);
    }

    private void Generate(TowerGenerationSettings generationSettings ,Transform tower)
    {
        List<Platform> spawnedPlatforms = SpawnPlatforms(generationSettings ,out float offsetFromTop);
        FitTowerHeight(tower, offsetFromTop);
        spawnedPlatforms.ForEach(platform => platform.transform.SetParent(tower));
    }

    private List<Platform> SpawnPlatforms(TowerGenerationSettings generationSettings ,out float offsetFromTop)
    {
        offsetFromTop = generationSettings.OffsetBetweenPlatforms;
        const int startAndLastPlatform = 2;
        var spawnedPlatforms = new List<Platform>(generationSettings.PlatformVariantCount + startAndLastPlatform);

        Platform startPlatform = Create(generationSettings.StartPlatformPrefab, RotationRange ,ref offsetFromTop);
        spawnedPlatforms.Add(startPlatform);

        for(int i = 0; i < generationSettings.PlatformVariantCount; i++)
        {
            Platform platform =  Create(generationSettings.PlatfornmVariantPrefab, RotationRange, ref offsetFromTop);
            spawnedPlatforms.Add(platform);
        }

        Platform finishPlatform = Create(generationSettings.FinishPlatformPrefab, RotationRange, ref offsetFromTop);
        spawnedPlatforms.Add(finishPlatform);

        return spawnedPlatforms;
    }


    private Platform Create(Platform platformPrefab, FloatRange rotationRange, ref float offsetFromTop)
    {
        Platform createdPlatform = Instantiate(platformPrefab);

        Transform platformTransform = createdPlatform.transform;

        platformTransform.position = Vector3.down * offsetFromTop;
        platformTransform.eulerAngles = GetRandomYRotation(rotationRange);

        offsetFromTop += platformTransform.localScale.y + _towerGenerationSettings.OffsetBetweenPlatforms;

        return createdPlatform;
    }
    private Vector3 GetRandomYRotation(FloatRange rotationRange) =>
        Vector3.up * rotationRange.Random ;

    private void FitTowerHeight(Transform tower, float heihght)
    {
        Vector3 originalSize = tower.localScale;
        float towerHeight = heihght / 2.0f;
        tower.localScale = new Vector3(originalSize.x, towerHeight, originalSize.z);
        tower.localPosition -= Vector3.up * towerHeight;
    }
}
