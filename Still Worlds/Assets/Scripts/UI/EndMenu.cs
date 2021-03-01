using UnityEngine;

namespace UI
{
    public class EndMenu : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Application.Quit();
            }
        }
    }
}
