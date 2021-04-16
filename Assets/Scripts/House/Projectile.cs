using Enemy;
using UnityEngine;

namespace House
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private ParticleSystem explosionParticle;
        [SerializeField] private float damage = 10f;
        [SerializeField] private Tag enemyTag;
        [SerializeField] private Tag obstacleTag;
        
 

        private void OnCollisionEnter(Collision other)
        {
           
            if (other.collider.HasTag(enemyTag))
            {
                other.collider.GetComponent<Health>().TakeDamage(damage);
                explosionParticle.Play();
                Invoke(nameof(Destroy), 1);
            }

            if (other.collider.HasTag(obstacleTag))
            {
                explosionParticle.Play();
                Invoke(nameof(Destroy), 0.5f);
            }
            
          
        }

        private void Destroy()
        {
            gameObject.SetActive(false);
        }
    }
}
