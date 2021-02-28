using Gameplay.Interactors;
using UI;
using UnityEngine;

namespace Gameplay.Characters
{
    public class PlayerCharacter : MonoBehaviour, ICharacter
    {
        public float MovementSpeed = 1.0f;
        public float RotationSpeed = 1.0f;
        public SpawnLocation spawnLocation;

        private Interactor interactor = null;
        private Portal portal = null;

        private HUD hud = null;
        private GameObject deathScreen;

        private int life = 3100;
        private int kill = 0;

        public void Start()
        {
            // Initialize HUD
            GameObject[] hudObjects = GameObject.FindGameObjectsWithTag("HUD");
            if (hudObjects.Length > 1)
            {
                Debug.LogError("More than one HUD has been found here!");
            }
            else if (hudObjects.Length == 0)
            {
                hud = null;
            }
            else
            {
                hud = hudObjects[0].GetComponent<HUD>();
                // Set HUD initial parameters
                hud.UpdateLife(life);
                hud.UpdateKill(kill);
            }

            // Initialize death screen
            GameObject[] deathScreenObjects = GameObject.FindGameObjectsWithTag("DeathScreen");
            if (deathScreenObjects.Length > 1)
            {
                Debug.LogError("More than one death screen has been found here!");
            }
            else if (deathScreenObjects.Length == 0)
            {
                deathScreen = null;
            }
            else
            {
                deathScreen = deathScreenObjects[0].transform.GetChild(0).gameObject;
            }

            // Set initial spawn location
            transform.position = spawnLocation.Location;
            transform.rotation = Quaternion.identity;
        }

        public void Resume()
        {
            life = 1;
            deathScreen.SetActive(false);
            transform.position = spawnLocation.Location;
            transform.rotation = Quaternion.identity;
        }

        public void Update()
        {
            if (hud != null)
            {
                // Update life parameters
                hud.UpdateLife(life);
                hud.UpdateKill(kill);
            }
            if (life <= 0)
            {
                deathScreen.SetActive(true);
            }
        }

        public void OnTriggerEnter(Collider other)
        {
            // On collision with the NPC
            if (other.CompareTag("NPC"))
            {
                Interactor NPCCharacter = other.GetComponent<Interactor>();
                NPCCharacter.ShowInteraction();
                interactor = NPCCharacter;
            }
            // On collision with portal
            else if (other.CompareTag("Portal"))
            {
                portal = other.GetComponent<Portal>();
                portal.ShowInteraction();
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (interactor != null)
            {
                interactor.HideInteraction();
            }
            if (portal != null)
            {
                portal.HideInteraction();
            }
            interactor = null;
            portal = null;
        }

        #region ICharacter
        public float GetMovementSpeed()
        {
            return MovementSpeed;
        }

        public float GetRotationSpeed()
        {
            return RotationSpeed;
        }

        public Interactor GetInteractor()
        {
            return interactor;
        }

        public Portal GetPortal()
        {
            return portal;
        }

        public int GetLife()
        {
            return life;
        }

        public void SetLife(int _life)
        {
            life = _life;
            if (life <= 0)
            {
                int currentKill = GetKill();
                currentKill++;
                SetKill(currentKill);
            }
        }

        public int GetKill()
        {
            return kill;
        }

        public void SetKill(int _kill)
        {
            kill = _kill;
        }

        public void Attack()
        {
            // Lose one LIFE when attacking
            int currentLife = GetLife();
            currentLife--;
            SetLife(currentLife);
        }

        public void TakeHit()
        {
            // Lose one LIFE when taking a hit
            int currentLife = GetLife();
            currentLife--;
            SetLife(currentLife);
        }
        #endregion
    }
}
