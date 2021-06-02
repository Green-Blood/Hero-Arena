using System;
using UnityEngine;

namespace Hero
{
    public class DistanceChecker : MonoBehaviour
    {
        [SerializeField] private HeroWarrior heroWarrior;
        [SerializeField] private Tag enemyTag;
        

        private void OnTriggerEnter(Collider other)
        {
            if(!other.HasTag(enemyTag)) return;
            heroWarrior.OnEnterAction?.Invoke(other.transform);   
        }
    }
}
