using Core;
using Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

namespace Hero
{
    public class HeroAttack : AttackHandler, IAttack
    {
        [Title("References")]
        [SerializeField] private Animator animator;
        [SerializeField] private NavMeshAgent agent;
        
        [Title("Parameters")]
        [SerializeField] private float attackRange = 4f;

        [HideInInspector]
        public bool canAttack = true;

        public void Attack()
        {
            if (!canAttack) return;
            if (agent.remainingDistance < attackRange)
            {
                animator.SetTrigger(AnimatorTexts.Attack);   
                agent.isStopped = true;
            }
            else agent.isStopped = false;
            
        }
         
       
    }
}
