using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class SceneLoading : MonoBehaviour
    {
        public static readonly int loadingScene = 2;
        public static readonly int mainMenuScene = 3;
        public static int sceneToLoad;

        private void Start()
        {
            StartCoroutine(LoadAsyncOperation());
        }

        public IEnumerator LoadAsyncOperation()
        {
            // Start scene loading
            AsyncOperation gameLevel = SceneManager.LoadSceneAsync(sceneToLoad);
            // Wait for scene to load
            while (gameLevel.progress < 1.0f)
            {
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
