using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    [SerializeField] private BallBounce _bounce;
    [SerializeField] private BallEffects _effects;
    [SerializeField] private Transform _ball;

    private bool _collided;

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.TryGetComponent(out PlatformObstacle _))
        {
            Destroy();
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

    private void Destroy()
    {
        _effects.EmutDestroyParticles(_ball.position);

        Destroy(_ball.gameObject);
    }
}
