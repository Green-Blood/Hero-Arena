using System;
using UnityEngine;

namespace Hero
{
    public class DistanceChecker : MonoBehaviour
    {
        [SerializeField] private HeroManager heroManager;
        [SerializeField] private Tag enemyTag;
        

        private void OnTriggerEnter(Collider other)
        {
            if(!other.HasTag(enemyTag)) return;
            heroManager.OnEnterAction?.Invoke(other.transform);   
        }
    }
}
