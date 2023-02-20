using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ReadOnlyListExtentions
{
    public static T Random<T>(this IReadOnlyList<T> list)
    {
        int randomIndex = UnityEngine.Random.Range(0, list.Count);
        return list[randomIndex];
    }
}
