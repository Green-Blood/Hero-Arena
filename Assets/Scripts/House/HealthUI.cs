using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace House
{
    public class HealthUI : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI healthText;
        [SerializeField] private Health health;

        private void OnEnable() => health.OnHealthChangedAction += OnHealthChangedAction;
        private void OnDisable() => health.OnHealthChangedAction -= OnHealthChangedAction;

        private void OnHealthChangedAction(float currentHealth, float maxHealth)
        {
            healthText.text = currentHealth.ToString("F") + " / " + maxHealth.ToString("F");
        }

        
    }
}
