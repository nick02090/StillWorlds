using Gameplay.Interactors;
using UnityEngine;

namespace Gameplay.Characters
{
    public class PlayerCharacter : MonoBehaviour, ICharacter
    {
        public float MovementSpeed = 1.0f;
        public float RotationSpeed = 1.0f;

        private Interactor interactor = null;
        private Portal portal = null;

        public void OnTriggerEnter(Collider other)
        {
            // On collision with the NPC
            if (other.CompareTag("NPC"))
            {
                Interactor NPCCharacter = other.GetComponent<Interactor>();
                NPCCharacter.ShowInteraction();
                interactor = NPCCharacter;
            }
            // On collision with portal
            else if (other.CompareTag("Portal"))
            {
                portal = other.GetComponent<Portal>();
                portal.ShowInteraction();
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (interactor != null)
            {
                interactor.HideInteraction();
            }
            if (portal != null)
            {
                portal.HideInteraction();
            }
            interactor = null;
            portal = null;
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
            return interactor;
        }

        public Portal GetPortal()
        {
            return portal;
        }
        #endregion
    }
}
