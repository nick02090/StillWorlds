using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HUD : MonoBehaviour
    {
        public Text LifeText;
        public Text KillText;

        public void UpdateLife(int life)
        {
            LifeText.text = $"{life}";
        }

        public void UpdateKill(int kill)
        {
            KillText.text = $"{kill}";
        }
    }
}

