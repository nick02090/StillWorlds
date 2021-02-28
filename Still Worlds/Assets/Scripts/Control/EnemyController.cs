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
        private FSMAI ai;

        private NavMeshAgent agent;
        private ICharacter enemyCharacter;

        void Start()
        {
            // Initialize member variables
            agent = GetComponent<NavMeshAgent>();
            enemyCharacter = GetComponent<EnemyCharacter>();
            // Initialize AI
            GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
            EnemyState startingState = new SearchState(gameObject, agent, playerGameObject, enemyCharacter);
            ai = new FSMAI(startingState);
        }

        private void Update()
        {
            ai.Update();
        }
    }
}
