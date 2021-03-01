using UnityEngine;

namespace Gameplay.Characters
{
    public class SpecialDeathCharacter : NPCCharacter
    {
        public GameObject portal;

        public override void SpecialAction()
        {
            portal.SetActive(true);
            ICharacter playerCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<ICharacter>();
            playerCharacter.SetLife(playerCharacter.GetLife() + playerCharacter.GetKill() * 666);
            playerCharacter.SetKill(0);
            Destroy(gameObject);
        }
    }
}
