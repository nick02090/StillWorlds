using Core;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Interactors
{
    public class Interactor : MonoBehaviour
    {
        public Text InteractionButton;
        public Messages[] messages;

        public delegate void FirstInteractionEnd();
        public FirstInteractionEnd onFirstInteractionEnd;

        private int intercationIndex = 0;
        private int messageIndex;
        private Dialogue dialogue;

        private void Start()
        {
            GameObject[] dialogueObjects = GameObject.FindGameObjectsWithTag("Dialogue");
            if (dialogueObjects.Length > 1)
            {
                Debug.LogError("More than one dialogue has been found here!");
            }
            dialogue = dialogueObjects[0].GetComponent<Dialogue>();
            HideInteraction();
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
            messageIndex = 0;
            dialogue.StartDialogue(messages[intercationIndex].Get(messageIndex));
        }

        public void FinishInteraction()
        {
            if (intercationIndex == 0)
            {
                onFirstInteractionEnd?.Invoke();
            }
            dialogue.EndDialogue();
            intercationIndex++;
            if (intercationIndex >= messages.Length)
            {
                intercationIndex--;
            }
        }

        /// <summary>
        /// Returns false if the interaction has finished, true otherwise.
        /// </summary>
        /// <returns></returns>
        public bool ContinueInteraction()
        {
            // Finish message typing if it's still typing
            if (dialogue.IsMessageTyping())
            {
                dialogue.FinishMessage();
                return true;
            }

            // Print out a next message
            messageIndex++;
            if (!messages[intercationIndex].IsOverflow(messageIndex))
            {
                dialogue.NextMessage(messages[intercationIndex].Get(messageIndex));
                return true;
            }
            else
            {
                FinishInteraction();
                return false;
            }
        }
    }
}
