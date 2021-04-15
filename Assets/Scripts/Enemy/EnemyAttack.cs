using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Tag playerTag;
        [SerializeField] private float damage = 20f;
        public void Attack()
        {
            animator.SetTrigger(AnimatorTexts.Attack);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.HasTag(playerTag)) other.GetComponent<Health>().TakeDamage(damage);

        }
    }
}
