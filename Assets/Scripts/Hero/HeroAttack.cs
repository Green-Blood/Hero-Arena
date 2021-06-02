using Core;
using Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace Hero
{
    public class HeroAttack : MonoBehaviour, IAttack
    {
        [SerializeField] private float attackRange = 4f;
        [SerializeField] private MeleeAttackHandler meleeAttackHandler;
       
        [HideInInspector]
        public bool canAttack = true;
      
        
        public void Attack()
        {
            if (!canAttack) return;
            meleeAttackHandler.Attack(attackRange);
            var value = Random.Range(0, 3);
            
        }
       
    }
}
