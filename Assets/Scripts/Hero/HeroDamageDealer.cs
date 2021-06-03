using Enemy;
using Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Hero
{
    public class HeroDamageDealer : MonoBehaviour
    {
        [Title("Parameters")]
        [SerializeField] private float damage = 20f;

        [SerializeField] private HeroAttack attackHandler;
        [SerializeField] private Tag targetTag;

    
        private void OnTriggerEnter(Collider other)
        {
            if(!attackHandler.canDealDamage) return;
            if (other.HasTag(targetTag))
            {
                other.GetComponent<IDamageable>().TakeDamage(damage);
            }
        }

  
    }
}
