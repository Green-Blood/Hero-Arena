using System;
using UnityEngine;

namespace Hero
{
    public class DistanceChecker : MonoBehaviour
    {
        [SerializeField] private HeroController heroController;
        [SerializeField] private Tag enemyTag;
        

        private void OnTriggerEnter(Collider other)
        {
            if(!other.HasTag(enemyTag)) return;
            heroController.OnEnterAction?.Invoke(other.transform);   
        }
    }
}
