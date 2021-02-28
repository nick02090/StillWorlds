using Gameplay.Characters;
using UnityEngine;
using UnityEngine.AI;

namespace AI.Enemy.States
{
    public class IdleState : EnemyState
    {
        public IdleState(GameObject _enemy, NavMeshAgent _agent, GameObject _player, ICharacter _enemyCharacter) : base(_enemy, _agent, _player, _enemyCharacter)
        {
            name = State.IDLE;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Update()
        {
            Vector3 spawnLocation = enemyCharacter.GetSpawnLocation();
            spawnLocation.y = enemyGameObject.transform.position.y;
            if (Vector3.Distance(enemyGameObject.transform.position, spawnLocation) > 0.01f)
            {
                // Nothing more to do, just go to the spawn position
                float step = enemyCharacter.GetMovementSpeed() * Time.deltaTime; // calculate distance to move
                enemyGameObject.transform.position = Vector3.MoveTowards(enemyGameObject.transform.position, spawnLocation, step);
                TurnXTowardsY(enemyGameObject, enemyCharacter.GetSpawnLocation());
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
