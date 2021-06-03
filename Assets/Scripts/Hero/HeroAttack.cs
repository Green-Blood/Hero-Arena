using Core;
using Interfaces;
using UnityEngine;


namespace Hero
{
    public class HeroAttack : AttackHandler, IAttack
    {
        [HideInInspector]
        public bool canAttack = true;

        public void Attack()
        {
            if (!canAttack) return;
            int attackVariant = Random.Range(0, 3);
            if (agent.remainingDistance < attackRange)
            {
                animator.SetTrigger(AnimatorTexts.Attack);   
                animator.SetInteger(AnimatorTexts.AttackValue, attackVariant);
                agent.isStopped = true;
                
            }
            else agent.isStopped = false;
        }
        
    }
}
