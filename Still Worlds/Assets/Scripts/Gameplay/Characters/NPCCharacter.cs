using Gameplay.Interactors;
using UnityEngine;

namespace Gameplay.Characters
{
    public class NPCCharacter : MonoBehaviour, ICharacter
    {
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
