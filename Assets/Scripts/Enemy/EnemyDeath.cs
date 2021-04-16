using Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyDeath : MonoBehaviour, IDeath
    {
        [SerializeField] private Animator animator;
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Rigidbody enemyRigidbody;

        public void Die()
        {
            animator.SetTrigger(AnimatorTexts.DieTrigger);
            agent.isStopped = true;
            enemyRigidbody.useGravity = false;
        }
    }
}