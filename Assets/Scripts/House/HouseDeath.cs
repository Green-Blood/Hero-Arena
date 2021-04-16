using Interfaces;
using UnityEngine;

namespace House
{
    public class HouseDeath : MonoBehaviour, IDeath
    {
        public void Die()
        {
            Debug.Log("Ded inside");
        }
    }
}
