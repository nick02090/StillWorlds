using Core;
using UnityEngine;

namespace UI
{
    public class Dialogue : MonoBehaviour
    {
        public RectTransform DialoguePanel;

        private AutoType DialogueTyper;

        private void Start()
        {
            DialogueTyper = DialoguePanel.GetChild(0).GetComponent<AutoType>();
            HideDialoguePanel();
        }

        public void StartDialogue(string message)
        {
            ShowDialoguePanel();
            DialogueTyper.StartTyping(message);
        }

        public void EndDialogue()
        {
            HideDialoguePanel();
        }

        public bool IsMessageTyping()
        {
            return DialogueTyper.IsTyping();
        }

        public void FinishMessage()
        {
            DialogueTyper.FinishUp();
        }

        public void NextMessage(string message)
        {
            DialogueTyper.StartTyping(message);
        }

        private void ShowDialoguePanel()
        {
            DialoguePanel.gameObject.SetActive(true);
        }
        private void HideDialoguePanel()
        {
            DialoguePanel.gameObject.SetActive(false);
        }
    }
}
