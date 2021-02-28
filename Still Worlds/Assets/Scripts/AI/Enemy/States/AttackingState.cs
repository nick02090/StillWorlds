using Gameplay.Characters;
using UnityEngine;
using UnityEngine.AI;

namespace AI.Enemy.States
{
    public class AttackingState : EnemyState
    {
        public AttackingState(GameObject _enemy, NavMeshAgent _agent, GameObject _player, ICharacter _enemyCharacter) : base(_enemy, _agent, _player, _enemyCharacter)
        {
            name = State.ATTACKING;
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
                    // Check if you have more than one life
                    if (enemyCharacter.GetLife() == 1)
                    {
                        nextState = new IdleState(enemyGameObject, agent, playerGameObject, enemyCharacter)
                        {
                            onAttack = onAttack
                        };
                        stage = Event.EXIT;
                        return;
                    }
                    // Attack him
                    onAttack?.Invoke();
                    return;
                }
                else
                {
                    // Go towards the hearing sound
                    nextState = new ChaseState(enemyGameObject, agent, playerGameObject, enemyCharacter)
                    {
                        onAttack = onAttack
                    };
                    stage = Event.EXIT;
                    return;
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
