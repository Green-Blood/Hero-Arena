using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Transform player;

        [SerializeField] private Animator animator;
        

        private void Awake()
        {
            agent.SetDestination(player.position);
        }

        private void Update()
        {
            animator.SetFloat(AnimatorTexts.Speed, agent.speed);
            if (agent.remainingDistance < 1f)
            {
                animator.SetTrigger(AnimatorTexts.Attack);
            
            }
        }
    }
}    
