using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Characters
{
    public class NPCCharacter : MonoBehaviour, ICharacter
    {
        public Text InteractionButton;

        private void Start()
        {
            HideInteraction();
        }

        #region ICharacter
        public float GetMovementSpeed()
        {
            return 0.0f;
        }

        public float GetRotationSpeed()
        {
            return 0.0f;
        }

        public void HideInteraction()
        {
            InteractionButton.gameObject.SetActive(false);
        }

        public void ShowInteraction()
        {
            InteractionButton.gameObject.SetActive(true);
        }

        public void Interact()
        {
            // Start a dialogue
            Debug.Log("Yay, we're interacting!");
        }

        public bool IsInteractable()
        {
            return true;
        }

        public void SetInteractor(ICharacter character)
        {
            throw new System.NotImplementedException();
        }

        public ICharacter GetInteractor()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
