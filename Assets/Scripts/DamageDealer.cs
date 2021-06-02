using Core;
using Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [Title("Parameters")]
    [SerializeField] private float damage = 20f;

    [SerializeField] private MeleeAttackHandler attackHandler;
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
