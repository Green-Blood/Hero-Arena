using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Animator animator;
        [SerializeField] private Movement enemyMovement;
        [SerializeField] private Health enemyHealth;
        
        private Transform _player;
        
        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void Update()
        {
            if (enemyHealth.IsDead) return;
            agent.SetDestination(_player.position);
            animator.SetFloat(AnimatorTexts.Speed, enemyMovement.GetCurrentSpeed());
           
          
        }
    }
}    
