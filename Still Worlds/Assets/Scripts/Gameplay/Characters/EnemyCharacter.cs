using Gameplay.Interactors;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Gameplay.Characters
{
    public class EnemyCharacter : MonoBehaviour, ICharacter
    {
        public float MovementSpeed;
        public float RotationSpeed;
        public int InitLife;
        public float visionDistance;
        public float hearingDistance;
        public float visionAngle;

        private readonly int finalSceneIndex = 9;

        public WorldPoint spawnLocation;
        public SearchPath searchPath;

        private int life;
        private Quaternion m_rotation;

        private void Awake()
        {
            // Initialize member variables
            life = InitLife;

            // Set initial spawn location
            transform.position = spawnLocation.Location;
            transform.rotation = Quaternion.identity;
        }

        private void Update()
        {
            // Destroy if killed
            if (life <= 0)
            {
                Destroy(gameObject);
            }
            // Update the rotation
            gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, m_rotation, Time.deltaTime * RotationSpeed);
        }

        public void Resume()
        {
            transform.position = spawnLocation.Location;
            transform.rotation = Quaternion.identity;
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
            // Final scene is the showdown!!!
            if (SceneManager.GetActiveScene().buildIndex == finalSceneIndex)
            {
                return;
            }

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

        public float GetVisionDistance()
        {
            return visionDistance;
        }

        public float GetHearingDistance()
        {
            return hearingDistance;
        }

        public float GetVisionAngle()
        {
            return visionDistance;
        }

        public SearchPath GetSearchPath()
        {
            return searchPath;
        }

        public void SetRotation(Quaternion _rotation)
        {
            m_rotation = _rotation;
        }

        public Vector3 GetSpawnLocation()
        {
            return spawnLocation.Location;
        }
        #endregion
    }
}
