using System;
using Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyAttack : MonoBehaviour, IAttack
    {
        [Title("References")]
        [SerializeField] private Animator animator;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Health enemyHealth;
        [SerializeField] private float attackRange = 1f;
        private void Update()
        {
            if(enemyHealth.IsDead) return;
            if (agent.remainingDistance < attackRange)
            {
                Attack();
                agent.isStopped = true;
            }
            else
            {
                agent.isStopped = false;
            }
        }
        public void Attack()
        {
            
            animator.SetTrigger(AnimatorTexts.Attack);
        }
    }
}