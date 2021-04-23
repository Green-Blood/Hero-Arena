using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class DamageDealer : MonoBehaviour

{
    [Title("Parameters")]
    [SerializeField] private float damage = 20f;
    [SerializeField] private Tag targetTag;
    private void OnTriggerEnter(Collider other)
    {
        if (other.HasTag(targetTag))
        {
            other.GetComponent<Health>().TakeDamage(damage);
             
        }
       
    }
}
