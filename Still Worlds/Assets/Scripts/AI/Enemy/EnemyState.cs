using Gameplay.Characters;
using UnityEngine;
using UnityEngine.AI;

namespace AI.Enemy
{
    public class EnemyState : IState
    {
        public delegate void OnAttack();
        public OnAttack onAttack;

        public enum State
        {
            IDLE, SEARCH, CHASE, ATTACKING
        };

        public enum Event
        {
            ENTER, UPDATE, EXIT
        };

        // To store the name of the STATE
        public State name;
        // To store the stage the EVENT is in
        public Event stage;
        // To store the NPC game object
        protected GameObject enemyGameObject;
        // To store the player game object
        protected GameObject playerGameObject;
        // The state that gets to run after the one currently running
        protected EnemyState nextState;
        // To store the enemy NavMeshAgent component
        protected NavMeshAgent agent;
        // To store enemy characteristics
        protected ICharacter enemyCharacter;

        protected float visDist;
        protected float hearDist;
        protected float visAngle;

        public EnemyState(GameObject _enemy, NavMeshAgent _agent, GameObject _player, ICharacter _enemyCharacter)
        {
            enemyGameObject = _enemy;
            agent = _agent;
            playerGameObject = _player;
            enemyCharacter = _enemyCharacter;

            visDist = _enemyCharacter.GetVisionDistance();
            hearDist = _enemyCharacter.GetHearingDistance();
            visAngle = _enemyCharacter.GetVisionAngle();
        }

        protected bool CanHearPlayer()
        {
            Vector3 direction = playerGameObject.transform.position - enemyGameObject.transform.position;

            if (direction.magnitude <= hearDist)
            {
                return true;
            }
            return false;
        }

        protected void TurnXTowardsY(GameObject gameObject, Vector3 y_position)
        {
            var lookPos = y_position - gameObject.transform.position;
            lookPos.y = 0;
            if (lookPos != Vector3.zero)
            {
                var rotation = Quaternion.LookRotation(lookPos);
                enemyCharacter.SetRotation(rotation);
            }
        }

        protected void TurnTowardsPlayer()
        {
            TurnXTowardsY(enemyGameObject, playerGameObject.transform.position);
        }

        protected bool CanSeePlayer()
        {
            Vector3 direction = playerGameObject.transform.position - enemyGameObject.transform.position;
            float angle = Vector3.Angle(direction, enemyGameObject.transform.forward);

            if (direction.magnitude < visDist && angle < visAngle)
            {
                return true;
            }
            return false;
        }

        #region IState
        public virtual void Enter()
        {
            stage = Event.UPDATE;
        }

        public virtual void Exit()
        {
            stage = Event.EXIT;
        }

        public IState Process()
        {
            if (stage == Event.ENTER) Enter();
            if (stage == Event.UPDATE) Update();
            if (stage == Event.EXIT)
            {
                Exit();
                return nextState;
            }
            return this;
        }

        public virtual void Update()
        {
            stage = Event.UPDATE;
        }
        #endregion
    }
}
