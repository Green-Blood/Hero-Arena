using Core;
using UnityEngine;

namespace Enemy
{
    public class EnemyDamageDealer : DamageDealer
    {
        [SerializeField] private EnemyAttack attackHandler;


        private void OnTriggerEnter(Collider other)
        {
            if (!attackHandler.canDealDamage) return;
            if (other.HasTag(targetTag)) DealDamage(other);
        }
    }
}