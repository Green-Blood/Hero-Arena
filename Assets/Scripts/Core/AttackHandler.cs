using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

namespace Core
{
    public class AttackHandler : MonoBehaviour
    {
        [Title("References")]
        [SerializeField] protected Animator animator;
        [SerializeField] protected NavMeshAgent agent;
        [SerializeField] protected Movement movement;
       
        [Title("Parameters")] 
        [SerializeField] protected float attackRange = 1f;
        [SerializeField] protected float rotationSpeed = 1f;
        
        [HideInInspector]
        public bool canDealDamage;
        private void AllowDamage() => canDealDamage = true;
        private void ForbidDamage() => canDealDamage = false;

        
    }
}