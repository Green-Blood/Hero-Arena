using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Animator animator;
        [SerializeField] private Movement enemyMovement;
        
        private Transform _player;
        
        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player").transform;
        }
        public void Move(Vector3 playerPosition)
        {
            agent.SetDestination(playerPosition);
            animator.SetFloat(AnimatorTexts.Speed, enemyMovement.GetCurrentSpeed());
        }
    }
}    
