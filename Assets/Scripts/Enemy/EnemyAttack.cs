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
       

        public void Attack()
        {
            if (agent.remainingDistance < attackRange)
            {
                animator.SetTrigger(AnimatorTexts.Attack);   
                agent.isStopped = true;
            }
            else agent.isStopped = false;
            
        }
    }
}