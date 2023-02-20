using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Tower/TowerGenerationSettings", fileName = "TowerGenerationSettings")]
public class TowerGenerationSettings : ScriptableObject
{
    [SerializeField] [Min(0)] private int _platformVariantCount;
    [SerializeField] [Min(0.0f)] private float _offsetBetwenPlatforms;

    [SerializeField] private FloatRange _rotationRange;

    [Header("Platform Prefabs")]
    [SerializeField] private Platform _startPlatformPrefab;
    [SerializeField] private Platform _finishPlatformPrefab;
    [SerializeField] private Platform[] _platformVariantPrefabs = Array.Empty<Platform>();

    public int PlatformVariantCount => _platformVariantCount;

    public float OffsetBetweenPlatforms => _offsetBetwenPlatforms;

    public Platform StartPlatformPrefab => _startPlatformPrefab;

    public Platform FinishPlatformPrefab => _finishPlatformPrefab;

    public Platform PlatfornmVariantPrefab => _platformVariantPrefabs.Random();

    public FloatRange RotationRange => _rotationRange;
}
