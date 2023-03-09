using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlatformPart : MonoBehaviour
{
    public void UnhookBy(EjectionSo ejection, Vector3 centerOfPlatform)
    {
        Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
        transform.ClearParent();
        rigidbody.detectCollisions = false;
        ejection.PushOut(rigidbody, centerOfPlatform);
    }
}
