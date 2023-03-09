using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    [SerializeField] private BallBounce _bounce;
    [SerializeField] private BallEffects _effects;
    [SerializeField] private BallDestroyer _destroyer;
    

    private bool _collided;

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.TryGetComponent(out PlatformObstacle _))
        {
            _destroyer.Destroy();
            return;
        }

        if(_collided)
            return;

        _collided = true;

        _bounce.BounceOff(Vector3.up);
        _effects.EmitCollisionParticles(other);
    }

    private void OnCollisionExit(Collision other) 
    {
        _collided = false;
    }

}
