using Gameplay;
using Gameplay.Characters;
using UnityEngine;
using UnityEngine.AI;

namespace AI.Enemy.States
{
    public class SearchState : EnemyState
    {
        private float startTime;
        private float searchTime;
        private SearchPath searchPath;

        public SearchState(GameObject _enemy, NavMeshAgent _agent, GameObject _player, ICharacter _enemyCharacter) : base(_enemy, _agent, _player, _enemyCharacter)
        {
            name = State.SEARCH;
            searchPath = enemyCharacter.GetSearchPath();
        }

        public override void Enter()
        {
            startTime = Time.time;

            base.Enter();
        }

        public override void Update()
        {
            //if (Time.time - startTime > searchTime)
            //{
            //    nextState = new IdleState(enemyGameObject, agent, playerGameObject, enemyCharacter);
            //    stage = Event.EXIT;
            //}

            // Make a full route on every point
            // On every point look at random direction and look for a player (IDLE)
            // While going between points listen for a player
            //      - if you hear a player look at his direction
            //          - if you see him, start the chase (CHASE)
            //          - else continue your path
            //      - else continue your path

            // if you see a player at a certain distance (and you have more than one LIFE) - shoot
            // when you reach 1 LIFE go IDLE
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
