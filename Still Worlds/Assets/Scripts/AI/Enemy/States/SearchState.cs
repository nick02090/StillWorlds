using Gameplay.Characters;
using UnityEngine;
using UnityEngine.AI;

namespace AI.Enemy.States
{
    public class SearchState : EnemyState
    {
        public SearchState(GameObject _enemy, NavMeshAgent _agent, GameObject _player, ICharacter _enemyCharacter) : base(_enemy, _agent, _player, _enemyCharacter)
        {
            name = State.SEARCH;
        }
    }
}
