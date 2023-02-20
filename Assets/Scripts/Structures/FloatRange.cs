using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Structures/FloatRange", fileName = "FloatRange")]
public class FloatRange : Range<float>
{
    public float Random => UnityEngine.Random.Range(Min, Max);
}
