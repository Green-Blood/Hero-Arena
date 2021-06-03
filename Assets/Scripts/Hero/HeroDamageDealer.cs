using Core;
using Enemy;
using Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Hero
{
    public class HeroDamageDealer : DamageDealer
    {
        [Title("Parameters")]
        [SerializeField] private HeroAttack attackHandler;

        private void OnTriggerEnter(Collider other)
        {
            if(!attackHandler.canDealDamage) return;
            if (other.HasTag(targetTag))
            {
                DealDamage(other);
            }
        }
    }
}
