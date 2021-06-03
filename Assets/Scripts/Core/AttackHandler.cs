using UnityEngine;

namespace Core
{
    public class AttackHandler : MonoBehaviour
    {
        [HideInInspector]
        public bool canDealDamage;
        
        private void AllowDamage() => canDealDamage = true;
        private void ForbidDamage() => canDealDamage = false;
    }
}