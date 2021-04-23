using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

namespace Hero
{
    public class HeroController : MonoBehaviour
    {
        [TabGroup("Hero Parameters")]
        [SerializeField] private float attackDistance = 2f;
        
        [TabGroup("Hero References")]
        [SerializeField] private NavMeshAgent agent;
        [TabGroup("Hero References")]
        [SerializeField] private Animator animator;
        [TabGroup("Hero References")]
        [SerializeField] private HeroAttack heroAttack;
        [TabGroup("Hero References")]
        [SerializeField] private Movement heroMovement;
        
        private List<Transform> _enemies;
        private bool _isAnybodyAround;
        private Health _currentEnemyHealth;
        private int _currentIndex;
        
        private Vector3 _initialPosition;

        public Action<Transform> OnEnterAction;
        private void Awake()
        {
            _enemies = new List<Transform>();
            _initialPosition = transform.position;
        }

        private void OnEnable() => OnEnterAction += MoveTo;
        private void LateUpdate()
        {
            if (!agent.enabled) return;
            if (agent.remainingDistance < attackDistance)
            {
                agent.isStopped = true;
                heroAttack.Attack();
            }
            else
            {
                agent.isStopped = false;
            }
            
            Move();
            animator.SetFloat(AnimatorTexts.Speed, heroMovement.GetCurrentSpeed());
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
            heroAttack.canAttack = true;
        }
        private void MoveTo(Transform enemy)
        {
            if (!agent.enabled) return;
            _enemies.Add(enemy);
            SetCurrentEnemyHealth();
         
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void SetCurrentEnemyHealth()
        {
            if (_currentIndex <= _enemies.Count)
            {
                _currentEnemyHealth = _enemies[_currentIndex].GetComponent<Health>();
                _isAnybodyAround = true;
            }
            else
            {
                _isAnybodyAround = false;
                agent.SetDestination(_initialPosition);
                heroAttack.canAttack = false;
            }
        }
        
        private void OnDisable() => OnEnterAction -= MoveTo;
    }
}