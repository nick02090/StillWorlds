using Gameplay.Characters;
using UnityEngine;

namespace Gameplay
{
    public class GameCore : MonoBehaviour
    {
        private ICharacter playerCharacter;

        public int playerLife = 1;
        public int playerKill = 0;

        private void Awake()
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("GameCore");

            if (objs.Length > 1)
            {
                Destroy(this.gameObject);
            }

            DontDestroyOnLoad(this.gameObject);

            playerCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<ICharacter>();
            playerCharacter.SetLife(playerLife);
            playerCharacter.SetKill(playerKill);
        }
    }
}
