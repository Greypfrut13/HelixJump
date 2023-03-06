
using UnityEngine;

public class BallEffects : MonoBehaviour
{
    [SerializeField] private ParticleSystem _collisionParticlesPrefab;
    [SerializeField] private ParticleSystem _destroyParticlesPrefab;
    
    private ParticleSystem _collisionParticles;

    private void Start() 
    {
        _collisionParticles = Instantiate(_collisionParticlesPrefab);
    }

    public void EmitCollisionParticles(Collision other)
    {
        Vector3 collisionPosition = other.contacts[0].point;
        
        _collisionParticles.transform.position = collisionPosition;
        _collisionParticles.Play();
    }

    public void EmutDestroyParticles(Vector3 position)
    {
        Instantiate(_destroyParticlesPrefab, position, Quaternion.identity);
    }
}
