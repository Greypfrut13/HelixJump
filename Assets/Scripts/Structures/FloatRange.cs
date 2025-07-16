using UnityEngine;

namespace Structures
{
    [CreateAssetMenu(fileName = "FloatRange", menuName = "ScriptableObjects/Structures/FloatRange")]
    public class FloatRange : Range<float>
    {
        public float Random => UnityEngine.Random.Range(Min, Max);
    }
}