using System;
using UnityEngine;

namespace Spawn
{
    public class Waves : MonoBehaviour
    {
        
        private enum SpawnState
        {
            Spawning, Waiting, Counting
        }
        
        [Serializable]
        public struct Wave
        {
            public Tags[] enemyTags;
            public int enemyQuantity;
            public int enemySpawnRate;
            
        }
        
        [SerializeField] private float timeBetweenWaves = 3f;
        [SerializeField] private float waveCountDown;

        private SpawnState _state = SpawnState.Counting;
        
        public Action OnWaveEnd;

        private void Start()
        {
            SpawnWave();
        }

        public void SpawnWave()
        {
            
        }

    }
}
