using Core;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Dialogue : MonoBehaviour
    {
        public RectTransform DialoguePanel;
        public Text TextMessage;
        public Text TextName;
        public Text TextPage;
        public Image ImageNext;

        private AutoType DialogueTyper;
        private int messageCounter = 0;
        private int messageNumber = 0;

        private bool fadeImage = false;
        private bool isFading = false;

        private void Start()
        {
            DialogueTyper = TextMessage.GetComponent<AutoType>();
            HideDialoguePanel();
        }

        private void Update()
        {
            if (!isFading)
            {
                fadeImage = !fadeImage;
                StartCoroutine(FadeImage(fadeImage));
            }
        }

        private IEnumerator FadeImage(bool fadeAway)
        {
            isFading = true;
            // fade from opaque to transparent
            if (fadeAway)
            {
                // loop over 1 second backwards
                for (float i = 1; i >= 0; i -= Time.deltaTime)
                {
                    // set color with i as alpha
                    ImageNext.color = new Color(1, 1, 1, i);
                    yield return null;
                }
            }
            // fade from transparent to opaque
            else
            {
                // loop over 1 second
                for (float i = 0; i <= 1; i += Time.deltaTime)
                {
                    // set color with i as alpha
                    ImageNext.color = new Color(1, 1, 1, i);
                    yield return null;
                }
            }
            yield return new WaitForSeconds(0.5f);
            isFading = false;
        }

        public void StartDialogue(string message, int size)
        {
            ShowDialoguePanel();
            DialogueTyper.StartTyping(message);
            messageCounter = 1;
            messageNumber = size;
            TextPage.text = $"{messageCounter}/{messageNumber}";
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
            messageCounter++;
            TextPage.text = $"{messageCounter}/{messageNumber}";
        }

        private void ShowDialoguePanel()
        {
            DialoguePanel.gameObject.SetActive(true);
        }

        private void HideDialoguePanel()
        {
            DialoguePanel.gameObject.SetActive(false);
        }

        public void SetName(string interactorName)
        {
            TextName.text = interactorName;
        }
    }
}
