using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Enemy
{
    public class EnemyHealthBar : MonoBehaviour
    {
        [SerializeField] private Image healthBarImage;
        [SerializeField] private float healthBarUpdateTime;

        [SerializeField] private Health health;

        private void OnEnable() => health.OnHealthChangedAction += OnHealthChangedAction;
        private void OnDisable() => health.OnHealthChangedAction -= OnHealthChangedAction;

        private void OnHealthChangedAction(float currentHealth, float maxHealth)
        {

            var amount = currentHealth / maxHealth;
            StartCoroutine(OnHealthChangedCoroutine(amount));
        }

        private IEnumerator OnHealthChangedCoroutine(float amount)
        {
            float imageFillPercent = healthBarImage.fillAmount;
            float elapsed = 0f;

            while (elapsed < healthBarUpdateTime)
            {
                elapsed += Time.deltaTime;
                healthBarImage.fillAmount = Mathf.Lerp(imageFillPercent, amount, elapsed / healthBarUpdateTime);
                yield return null;
            }

            healthBarImage.fillAmount = amount;
            
        }
    }
}
