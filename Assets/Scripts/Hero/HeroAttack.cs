using Interfaces;
using UnityEngine;

namespace Hero
{
    public class HeroAttack : MonoBehaviour, IAttack
    {
        [SerializeField] private Animator animator;

        public bool canAttack;
        public void Attack()
        {
            if (!canAttack) return;
            animator.SetTrigger(AnimatorTexts.Attack);
        }
    }
}
