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
        #endregion
    }
}
