using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions
{
    public static void ClearParent(this Transform transform)
    {
        transform.SetParent(null);
    }
}
