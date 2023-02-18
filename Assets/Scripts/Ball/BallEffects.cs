
using UnityEngine;

public class BallEffects : MonoBehaviour
{
    [SerializeField] private ParticleSystem _collisionParticlesPrefab;

    private void OnCollisionEnter(Collision other)
    {
        EmitCollisionParticles(other);
    }

    private void EmitCollisionParticles(Collision other)
    {
        Vector3 collisionPosition = other.contacts[0].point;
        Instantiate(_collisionParticlesPrefab, collisionPosition, Quaternion.identity);
    }
}
