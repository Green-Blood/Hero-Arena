using System;
using Hero;
using UnityEngine;

namespace Enemy
{
    public class EnemyWorker : MonoBehaviour
    {
        [SerializeField] private EnemyAttack enemyAttack;
        [SerializeField] private EnemyMovement enemyMovement;
        [SerializeField] private Health enemyHealth;

        private Transform[] _playersTransforms;
        private Health[] _playersHealths;
        private int _playerIndex;

        private void Awake()
        {
            var players = GameObject.FindGameObjectsWithTag("Player");
            _playersTransforms = new Transform[players.Length];
            _playersHealths = new Health[players.Length];

            for (var index = 0; index < players.Length; index++)
            {
                var player = players[index];
                _playersTransforms[index] = player.transform;
                _playersHealths[index] = player.GetComponent<Health>();
            }
        }

        private void Update()
        {
            if (enemyHealth.IsDead) return;
            if (PlayerExists() && _playersHealths[_playerIndex].IsDead) _playerIndex++;
            if(!PlayerExists()) return;
            
            enemyMovement.Move(_playersTransforms[_playerIndex].position);
            enemyAttack.Attack();
        }

        private bool PlayerExists() => _playerIndex < _playersHealths.Length;
    }
}