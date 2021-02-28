using AI;
using AI.Enemy;
using AI.Enemy.States;
using Core;
using Gameplay.Characters;
using UnityEngine;
using UnityEngine.AI;

namespace Control
{
    public class EnemyController : MonoBehaviour
    {
        public ParticleSystem WalkParticle;
        public PoolManager PoolManager;

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
            EnemyState startingState;
            if (enemyCharacter.GetLife() > 1)
            {
                startingState = new SearchState(gameObject, agent, playerGameObject, enemyCharacter);
            }
            else
            {
                startingState = new IdleState(gameObject, agent, playerGameObject, enemyCharacter);
            }
            startingState.onAttack += OnAttack;
            ai = new FSMAI(startingState);
            // Initialize starting position
            lastPosition = transform.position;
        }

        private void FixedUpdate()
        {
            // Play the walking position
            if (Vector3.Distance(transform.position, lastPosition) > 0.001f)
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

        public void OnAttack()
        {
            enemyCharacter.Attack();
            PoolManager.CreateNext(GetComponent<Collider>(), transform.position + transform.forward + transform.up, transform.forward);
        }
    }
}
