using Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class GameOver : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // End scene
                SceneLoading.sceneToLoad = 10;
                SceneManager.LoadScene(SceneLoading.loadingScene);
            }
        }
    }
}
