using AI;
using AI.Enemy;
using AI.Enemy.States;
using Gameplay.Characters;
using UnityEngine;
using UnityEngine.AI;

namespace Control
{
    public class EnemyController : MonoBehaviour
    {
        public ParticleSystem WalkParticle;

        private FSMAI ai;
        private NavMeshAgent agent;
        private ICharacter enemyCharacter;

        private Vector3 lastPosition;

        private void Start()
        {
            // Initialize member variables
            agent = GetComponent<NavMeshAgent>();
            enemyCharacter = GetComponent<EnemyCharacter>();
            // Initialize AI
            GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
            EnemyState startingState = new SearchState(gameObject, agent, playerGameObject, enemyCharacter);
            ai = new FSMAI(startingState);
            // Initialize starting position
            lastPosition = transform.position;
        }

        private void FixedUpdate()
        {
            // Play the walking position
            if (transform.position != lastPosition)
            {
                WalkParticle.Play();
            }
            else
            {
                WalkParticle.Stop();
            }
            // Update the position
            lastPosition = transform.position;
        }

        private void Update()
        {
            // Update the AI
            ai.Update();
        }
    }
}
