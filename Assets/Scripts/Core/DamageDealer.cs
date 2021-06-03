using Interfaces;
using UnityEngine;

namespace Core
{
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField] protected float damage = 20f;
        [SerializeField] protected Tag targetTag;

        protected void DealDamage(Collider target) => target.GetComponent<IDamageable>().TakeDamage(damage);
    }
}
