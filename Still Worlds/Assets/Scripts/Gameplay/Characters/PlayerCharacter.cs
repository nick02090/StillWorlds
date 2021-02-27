using UnityEngine;

namespace Gameplay.Characters
{
    public class PlayerCharacter : MonoBehaviour, ICharacter
    {
        public float MovementSpeed = 1.0f;
        public float RotationSpeed = 1.0f;

        private ICharacter interactor = null;

        public void OnTriggerEnter(Collider other)
        {
            // On collision with the NPC
            if (other.CompareTag("NPC"))
            {
                ICharacter NPCCharacter = other.GetComponent<ICharacter>();
                if(NPCCharacter.IsInteractable())
                {
                    NPCCharacter.ShowInteraction();
                    interactor = NPCCharacter;
                }
            }
        }

        public void OnTriggerExit(Collider other)
        {
            interactor.HideInteraction();
            interactor = null;
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

        public void Interact()
        {
            return;
        }

        public bool IsInteractable()
        {
            return false;
        }

        public void ShowInteraction()
        {
            return;
        }

        public void HideInteraction()
        {
            return;
        }

        public ICharacter GetInteractor()
        {
            return interactor;
        }

        public void SetInteractor(ICharacter character)
        {
            interactor = character;
        }
        #endregion
    }
}
