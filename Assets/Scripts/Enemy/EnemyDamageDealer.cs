using Enemy;
using Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour
{
    [Title("Parameters")]
    [SerializeField] private float damage = 20f;

    [SerializeField] private EnemyAttack attackHandler;
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
