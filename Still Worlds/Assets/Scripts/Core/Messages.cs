using UnityEngine;

namespace Core
{
    public class Messages : MonoBehaviour
    {
        public string[] messages;

        public string Get(int index)
        {
            return messages[index];
        }

        public bool IsOverflow(int index)
        {
            return index >= messages.Length;
        }
    }
}
