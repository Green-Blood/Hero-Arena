using Interfaces;
using UnityEngine;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private float enemyHealth = 100f;
        [SerializeField] private Animator animator;
        private static readonly int DieTrigger = Animator.StringToHash("DieTrigger");

        public void TakeDamage(float value)
        {
            enemyHealth -= value;
        }

        public void Die()
        {
            animator.SetTrigger(DieTrigger);
        }
    }
}
