using System;
using Interfaces;
using UnityEngine;
using UnityEngine.AI;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 100f;
   
    public bool IsDead { get; private set; }
    
    private IDeath _death;
    private float _currentHealth;
    
    public Action<float, float> OnHealthChangedAction;

    private void Awake()
    {
        _currentHealth = maxHealth;
        _death = GetComponent<IDeath>();
    }

    public void TakeDamage(float value)
    {
        _currentHealth -= value;
        OnHealthChangedAction?.Invoke(_currentHealth, maxHealth);
        
        if (!(_currentHealth <= 0)) return;
        _death.Die();
        IsDead = true;
    }
}