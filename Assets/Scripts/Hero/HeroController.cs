using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Hero
{
    public class HeroController : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private Animator animator;
        [SerializeField] private HeroAttack heroAttack;
        [SerializeField] private float attackDistance = 2f;
        public Action<Transform> OnEnterAction;

        private List<Transform> _enemies;
        private int _currentIndex;
        private Health _currentEnemyHealth;
        private bool _isAnybodyAround;

        private void Awake()
        {
            _enemies = new List<Transform>();
        }

        private void OnEnable() => OnEnterAction += MoveTo;
        private void LateUpdate()
        {
            if (!agent.enabled) return;
            if (agent.remainingDistance < attackDistance)
            {
                heroAttack.Attack();
            }
            
            Move();
            animator.SetFloat(AnimatorTexts.Speed, agent.speed);
        }

        private void Move()
        {
            if (!_isAnybodyAround) return;
            if (_currentEnemyHealth.IsDead)
            {
                _currentIndex++;
                SetCurrentEnemyHealth();
            }
            agent.SetDestination(_enemies[_currentIndex].position);
        }
        private void MoveTo(Transform enemy)
        {
            if (!agent.enabled) return;
            _enemies.Add(enemy);
            SetCurrentEnemyHealth();
            heroAttack.canAttack = true;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void SetCurrentEnemyHealth()
        {
            if (_currentIndex < _enemies.Count)
            {
                _currentEnemyHealth = _enemies[_currentIndex].GetComponent<Health>();
                _isAnybodyAround = true;
            }
            else
            {
                _isAnybodyAround = false;
            }
           
            
        }
        
        private void OnDisable() => OnEnterAction -= MoveTo;
    }
}