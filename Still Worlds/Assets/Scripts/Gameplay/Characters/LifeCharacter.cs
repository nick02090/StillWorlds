using UnityEngine;

namespace Gameplay.Characters
{
    public class LifeCharacter : NPCCharacter
    {
        public GameObject portal;
        public int newLifeValue = 5;

        public override void SpecialAction()
        {
            portal.SetActive(true);
            GameObject.FindGameObjectWithTag("Player").GetComponent<ICharacter>().SetLife(newLifeValue);
            Destroy(gameObject);
        }
    }
}

