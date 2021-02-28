using Gameplay;
using Gameplay.Characters;
using UnityEngine;
using UnityEngine.AI;

namespace AI.Enemy.States
{
    public class SearchState : EnemyState
    {
        private readonly SearchPath searchPath;
        private Vector3 currentTargetPoint;

        public SearchState(GameObject _enemy, NavMeshAgent _agent, GameObject _player, ICharacter _enemyCharacter) : base(_enemy, _agent, _player, _enemyCharacter)
        {
            name = State.SEARCH;
            searchPath = enemyCharacter.GetSearchPath();
            currentTargetPoint = searchPath.GetNext();
            currentTargetPoint.y = enemyGameObject.transform.position.y;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void Update()
        {
            // Check if you can hear a player
            if (CanHearPlayer())
            {
                // Look at his direction
                TurnTowardsPlayer();
                // Check if you can see him
                if (CanSeePlayer())
                {
                    Debug.Log("I heard him, saw him and now im attacking");
                    // Attack him
                    nextState = new AttackingState(enemyGameObject, agent, playerGameObject, enemyCharacter);
                    stage = Event.EXIT;
                    return;
                }
                else
                {
                    Debug.Log("I heard him and now im chasing");
                    // Go towards the hearing sound
                    nextState = new ChaseState(enemyGameObject, agent, playerGameObject, enemyCharacter);
                    stage = Event.EXIT;
                    return;
                }
            }

            Debug.Log("Resuming my path to the target");
            // Move our position a step closer to the target.
            float step = enemyCharacter.GetMovementSpeed() * Time.deltaTime; // calculate distance to move
            enemyGameObject.transform.position = Vector3.MoveTowards(enemyGameObject.transform.position, currentTargetPoint, step);
            TurnXTowardsY(enemyGameObject, currentTargetPoint);

            // Calculate the positions based on X and Z axis (the height shouldn't matter in the path finding)
            Vector2 enemyLocation2D = new Vector2(enemyGameObject.transform.position.x, enemyGameObject.transform.position.z);
            Vector2 targetLocation2D = new Vector2(currentTargetPoint.x, currentTargetPoint.z);
            // Check if the positions are approximately equal.
            if (Vector2.Distance(enemyLocation2D, targetLocation2D) < 0.001f)
            {
                // Get the next point
                currentTargetPoint = searchPath.GetNext();
                currentTargetPoint.y = enemyGameObject.transform.position.y;
                Debug.Log("Changing the target");
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
