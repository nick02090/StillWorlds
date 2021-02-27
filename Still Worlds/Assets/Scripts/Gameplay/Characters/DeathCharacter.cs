using UnityEngine;

namespace Gameplay.Characters
{
    public class DeathCharacter : NPCCharacter
    {
        public GameObject portal;

        public override void SpecialAction()
        {
            portal.SetActive(true);
        }
    }
}
