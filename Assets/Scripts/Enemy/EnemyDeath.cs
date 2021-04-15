using Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyDeath : MonoBehaviour, IDeath
    {
        [SerializeField] private Animator animator;
        [SerializeField] private NavMeshAgent agent;

        public void Die()
        {
            animator.SetTrigger(AnimatorTexts.DieTrigger);
            agent.enabled = false;
        }
    }
}