using Gameplay.Characters;
using UnityEngine;
using UnityEngine.AI;

namespace AI.Enemy.States
{
    public class ChaseState : EnemyState
    {
        public ChaseState(GameObject _enemy, NavMeshAgent _agent, GameObject _player, ICharacter _enemyCharacter) : base(_enemy, _agent, _player, _enemyCharacter)
        {
            name = State.CHASE;
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
                    // Attack him
                    nextState = new AttackingState(enemyGameObject, agent, playerGameObject, enemyCharacter)
                    {
                        onAttack = onAttack
                    };
                    stage = Event.EXIT;
                    return;
                }
                else
                {
                    // Move our position a step closer to the player.
                    float step = enemyCharacter.GetMovementSpeed() * Time.deltaTime; // calculate distance to move
                    enemyGameObject.transform.position = Vector3.MoveTowards(enemyGameObject.transform.position, playerGameObject.transform.position, step);
                }
            }
            else
            {
                // Go back to path searching
                nextState = new SearchState(enemyGameObject, agent, playerGameObject, enemyCharacter)
                {
                    onAttack = onAttack
                };
                stage = Event.EXIT;
                return;
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}
