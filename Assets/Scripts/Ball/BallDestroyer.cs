using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class BallDestroyer : MonoBehaviour
{
    [SerializeField] private Transform _ball;
    [SerializeField] private BallEffects _effects;
    [SerializeField] private CinemachineImpulseSource _impulseSource;

    public void Destroy()
    {
        _effects.EmutDestroyParticles(_ball.position);
        _impulseSource.GenerateImpulse();

        Destroy(_ball.gameObject);
    }
}
