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
        public AudioClip sound;

        private void Start()
        {
            HideInteraction();
        }

        private void Update()
        {
            if (gameObject.activeInHierarchy & sound)
                GetComponent<AudioSource>().PlayOneShot(sound);
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
