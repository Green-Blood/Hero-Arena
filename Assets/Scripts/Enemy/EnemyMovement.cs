using Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour, IMovable
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Animator animator;
        [SerializeField] private Movement enemyMovement; 
        public void Move(Vector3 playerPosition)
        {
            agent.SetDestination(playerPosition);
            animator.SetFloat(AnimatorTexts.Speed, enemyMovement.GetCurrentSpeed());
        }
    }
}    
