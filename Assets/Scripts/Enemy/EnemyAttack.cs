using Core;
using Interfaces;

namespace Enemy
{
    public class EnemyAttack : AttackHandler, IAttack
    {
        
        public void Attack()
        {
            if (agent.remainingDistance < attackRange)
            {
                animator.SetTrigger(AnimatorTexts.Attack);   
                agent.isStopped = true;
                movement.RotateTowards(agent.destination, rotationSpeed);
            }
            else agent.isStopped = false;
            
        }
       
    }
}
