using System;
using Core;
using Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyAttack : MonoBehaviour, IAttack
    {
        [Title("References")] 
        [SerializeField] private MeleeAttackHandler meleeAttackHandler;
        [SerializeField] private float attackRange = 1f;

        public void Attack()
        {
             meleeAttackHandler.Attack(attackRange);
          
        }
    }
}