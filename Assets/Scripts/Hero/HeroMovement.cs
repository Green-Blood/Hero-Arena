using Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace Hero
{
    public class HeroMovement : MonoBehaviour, IMovable
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Animator animator;
        [SerializeField] private Movement heroMovement;
        public void Move(Vector3 enemyPosition)
        {
            agent.SetDestination(enemyPosition);
            animator.SetFloat(AnimatorTexts.Speed, heroMovement.GetCurrentSpeed());
        }
    }
}