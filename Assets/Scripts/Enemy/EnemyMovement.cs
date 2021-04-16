using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Animator animator;
         
        
        private Transform _player;

        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player").transform;
            agent.SetDestination(_player.position);
        }

        private void Update()
        {
            if(agent.isStopped) return;
            
            animator.SetFloat(AnimatorTexts.Speed, agent.speed);
          
        }
    }
}    
