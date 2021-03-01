using Core;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        public Text SaveInfoText;
        public Image EButton;
        public Text NameText;
        public Text GameNameText;

        private bool isAnimating = false;

        private void Update()
        {
            if (!isAnimating)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    isAnimating = true;
                    StartCoroutine(Animate());
                }
            }
        }

        private IEnumerator Animate()
        {
            // Hide the save info and E button
            EButton.gameObject.SetActive(false);
            yield return StartCoroutine(FadeAway(SaveInfoText));
            SaveInfoText.gameObject.SetActive(false);
            // Show my name
            NameText.gameObject.SetActive(true);
            yield return StartCoroutine(FadeIn(NameText));
            yield return new WaitForSeconds(2.0f);
            yield return StartCoroutine(FadeAway(NameText));
            NameText.gameObject.SetActive(false);
            // Show the game name
            GameNameText.gameObject.SetActive(true);
            yield return StartCoroutine(FadeIn(GameNameText));
            yield return new WaitForSeconds(3.0f);
            // Load the first scene
            StartTheGame();
        }

        private IEnumerator FadeAway(Text text)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                text.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }

        private IEnumerator FadeIn(Text text)
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                text.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }

        private void StartTheGame()
        {
            SceneLoading.sceneToLoad = 3;
            SceneManager.LoadScene(SceneLoading.loadingScene);
        }
    }
}
