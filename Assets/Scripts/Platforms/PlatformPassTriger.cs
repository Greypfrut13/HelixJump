using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlatformPassTriger : MonoBehaviour
{
    private Platform _parentPlatform;


    private void OnValidate() 
    {
        GetComponent<Collider>().isTrigger = true;
    }

    private void Start() 
    {
        _parentPlatform = GetComponentInParent<Platform>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.TryGetComponent(out BallCollision _) == false)
            return;
        
        _parentPlatform.UnhookAllParts();

        Destroy(gameObject);
    }
    
}
