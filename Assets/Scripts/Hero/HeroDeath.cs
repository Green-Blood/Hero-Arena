using Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace Hero
{
    public class HeroDeath : MonoBehaviour, IDeath
    {
        [SerializeField] private Animator animator;
        [SerializeField] private NavMeshAgent agent;
        

        public void Die()
        {
            animator.SetTrigger(AnimatorTexts.DieTrigger);
            agent.isStopped = true;
          
        }
    }
}
