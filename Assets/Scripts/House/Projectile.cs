using System;
using Enemy;
using UnityEngine;

namespace House
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private ParticleSystem explosionParticle;
        [SerializeField] private GameObject projectileMesh;
        [SerializeField] private float damage = 10f;
        [SerializeField] private Tag enemyTag;
        [SerializeField] private Tag obstacleTag;


        private void OnEnable()
        {
            //projectileMesh.SetActive(true);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!other.collider.HasTag(enemyTag) && !other.collider.HasTag(obstacleTag)) return;
            var health =  other.collider.GetComponent<Health>();
            if (health != null) health.TakeDamage(damage);
            
            explosionParticle.Play();
            //projectileMesh.SetActive(false);
            Invoke(nameof(Destroy), 1);
        }

        private void Destroy()
        {
            gameObject.SetActive(false);
        }
    }
}
