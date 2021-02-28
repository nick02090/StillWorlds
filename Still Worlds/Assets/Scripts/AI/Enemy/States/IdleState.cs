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
    }
}
