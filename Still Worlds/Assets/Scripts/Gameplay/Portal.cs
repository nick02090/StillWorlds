using Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Gameplay
{
    public class Portal : MonoBehaviour
    {
        public Text InteractionButton;
        public int sceneToLoad;

        private void Start()
        {
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
            LoadScene(sceneToLoad);
        }

        private void LoadScene(int sceneNumber)
        {
            if (SceneManager.GetActiveScene().buildIndex != sceneNumber)
            {
                SceneLoading.sceneToLoad = sceneNumber;
                SceneManager.LoadScene(SceneLoading.loadingScene);
            }
        }
    }
}
