using Gameplay.Interactors;
using UnityEngine;

namespace Gameplay.Characters
{
    public abstract class NPCCharacter : MonoBehaviour, ICharacter
    {
        private Interactor interactor;

        public abstract void SpecialAction();

        private void Start()
        {
            interactor = GetComponent<Interactor>();
            interactor.onFirstInteractionEnd += SpecialAction;
        }

        #region ICharacter
        public float GetMovementSpeed()
        {
            throw new System.NotImplementedException();
        }

        public float GetRotationSpeed()
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public void SetLife(int life)
        {
            throw new System.NotImplementedException();
        }

        public int GetKill()
        {
            throw new System.NotImplementedException();
        }

        public void SetKill(int kill)
        {
            throw new System.NotImplementedException();
        }

        public void Attack()
        {
            throw new System.NotImplementedException();
        }

        public void TakeHit()
        {
            throw new System.NotImplementedException();
        }

        public float GetVisionDistance()
        {
            throw new System.NotImplementedException();
        }

        public float GetHearingDistance()
        {
            throw new System.NotImplementedException();
        }

        public float GetVisionAngle()
        {
            throw new System.NotImplementedException();
        }

        public SearchPath GetSearchPath()
        {
            throw new System.NotImplementedException();
        }

        public void SetRotation(Quaternion rotation)
        {
            throw new System.NotImplementedException();
        }

        public Vector3 GetSpawnLocation()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
