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
        [SerializeField] private float attackRange = 1f;
        private void Update()
        {
            if(agent.isStopped) return;
            if (agent.remainingDistance < attackRange) Attack();
        }
        public void Attack()
        {
            animator.SetTrigger(AnimatorTexts.Attack);
        }
    }
}