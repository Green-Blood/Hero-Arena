using System;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Transform player;

    [SerializeField] private Animator animator;
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int Attack = Animator.StringToHash("Attack");

    private void Awake()
    {
        agent.SetDestination(player.position);
    }

    private void Update()
    {
        animator.SetFloat(Speed, agent.speed);
        if (agent.remainingDistance < 1f)
        {
            animator.SetTrigger(Attack);
            
        }
    }
}    
