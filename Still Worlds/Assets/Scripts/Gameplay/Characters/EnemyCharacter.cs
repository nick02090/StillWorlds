using Gameplay.Interactors;
using UnityEngine;

namespace Gameplay.Characters
{
    public class EnemyCharacter : MonoBehaviour, ICharacter
    {
        public float MovementSpeed;
        public float RotationSpeed;
        public int InitLife;

        private int life;

        private void Start()
        {
            // Initialize member variables
            life = InitLife;
        }

        private void Update()
        {
            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }

        #region ICharacter
        public float GetMovementSpeed()
        {
            return MovementSpeed;
        }

        public float GetRotationSpeed()
        {
            return RotationSpeed;
        }

        public Interactor GetInteractor()
        {
            throw new System.NotImplementedException();
        }

        public Portal GetPortal()
        {
            throw new System.NotImplementedException();
        }

        public int GetLife()
        {
            return life;
        }

        public void SetLife(int _life)
        {
            life = _life;
        }

        public int GetKill()
        {
            throw new System.NotImplementedException();
        }

        public void SetKill(int _kill)
        {
            throw new System.NotImplementedException();
        }

        public void Attack()
        {
            // Lose one LIFE when attacking
            int currentLife = GetLife();
            currentLife--;
            SetLife(currentLife);
        }

        public void TakeHit()
        {
            // Lose one LIFE when taking a hit
            int currentLife = GetLife();
            currentLife--;
            SetLife(currentLife);
        }
        #endregion
    }
}
