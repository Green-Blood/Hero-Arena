using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

namespace Hero
{
    public class HeroWarrior : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private HeroAttack heroAttack; 
        [SerializeField] private HeroMovement heroMovement;
        [SerializeField] private Health heroHealth;
        
        private List<Transform> _enemies;
        private List<Health> _enemiesHealth;
        private bool _isAnybodyAround;
        private Health _currentEnemyHealth;
        private int _currentIndex;
        private Vector3 _initialPosition;

        public Action<Transform> OnEnterAction;
        
        private void Awake()
        {
            _enemies = new List<Transform>();
            _enemiesHealth = new List<Health>();
            _initialPosition = transform.position;
        }

        private void OnEnable() => OnEnterAction += GetEnemies;
        private void GetEnemies(Transform enemy)
        {
            _enemies.Add(enemy);
            _enemiesHealth.Add(enemy.GetComponent<Health>());
            SetCurrentEnemyHealth();
        }
        private void LateUpdate()
        {
            if(heroHealth.IsDead) return;
            if (!_isAnybodyAround) return;

            heroMovement.Move(_enemies[_currentIndex].position);
            heroAttack.Attack();
            
            OnEnemyDeath();
        }

        private void OnEnemyDeath()
        {
            if (_currentEnemyHealth.IsDead)
            {
                _currentIndex++;
                SetCurrentEnemyHealth();
            }
            heroAttack.canAttack = true;
        }
        
        private void SetCurrentEnemyHealth()
        {
            if (_currentIndex <= _enemies.Count)
            {
                _currentEnemyHealth = _enemiesHealth[_currentIndex];
                _isAnybodyAround = true;
               
            }
            else
            {
                _isAnybodyAround = false;
                agent.SetDestination(_initialPosition);
                heroAttack.canAttack = false;
            }
        }
        
        private void OnDisable() => OnEnterAction -= GetEnemies;
    }
}