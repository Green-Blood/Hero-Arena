using Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

namespace Core
{
    public class MeleeAttackHandler : MonoBehaviour
    {
        [Title("References")]
        [SerializeField] private Animator animator;
        [SerializeField] private NavMeshAgent agent;
        [HideInInspector]
        public bool canDealDamage;
       
        
        public void Attack(float attackRange)
        {
            if (agent.remainingDistance < attackRange)
            {
                animator.SetTrigger(AnimatorTexts.Attack);   
                agent.isStopped = true;
            }
            else agent.isStopped = false;
            
        }
        private void AllowDamage() => canDealDamage = true;
        private void ForbidDamage() => canDealDamage = false;
    }
}
