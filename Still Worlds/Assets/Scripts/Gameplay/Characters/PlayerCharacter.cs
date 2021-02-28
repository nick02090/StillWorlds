using Gameplay.Interactors;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Characters
{
    public class PlayerCharacter : MonoBehaviour, ICharacter
    {
        public float MovementSpeed = 1.0f;
        public float RotationSpeed = 1.0f;
        public WorldPoint spawnLocation;

        private Interactor interactor = null;
        private Portal portal = null;

        private HUD hud = null;
        private GameObject deathScreenPanel;

        private int life = 1;
        private int kill = 0;

        private bool isSuicide = false;
        private readonly string suicideText = "You commited suicide by attacking with 1 LIFE.";
        private readonly string deathText = "An enemy killed you!";

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
                deathScreenPanel = null;
            }
            else
            {
                deathScreenPanel = deathScreenObjects[0].transform.GetChild(0).gameObject;
            }

            // Set initial spawn location
            transform.position = spawnLocation.Location;
            transform.rotation = Quaternion.identity;
        }

        public void Resume()
        {
            life = 1;
            isSuicide = false;
            deathScreenPanel.SetActive(false);
            transform.position = spawnLocation.Location;
            transform.rotation = Quaternion.identity;
            Time.timeScale = 1f;
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
                Text deathExplanaiton = deathScreenPanel.transform.GetChild(0).GetComponent<Text>();
                if (isSuicide)
                {
                    deathExplanaiton.text = suicideText;
                }
                else
                {
                    deathExplanaiton.text = deathText;
                }
                deathScreenPanel.SetActive(true);
                Time.timeScale = 0f;
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
            // Add a kill if you've attacked when having one LIFE left
            if (life <= 0)
            {
                int currentKill = GetKill();
                currentKill++;
                SetKill(currentKill);
                isSuicide = true;
            }
        }

        public void TakeHit()
        {
            // Lose one LIFE when taking a hit
            int currentLife = GetLife();
            currentLife--;
            SetLife(currentLife);
        }

        public float GetVisionDistance()
        {
            throw new System.NotImplementedException();
        }

        public float GetHearingDistance()
        {
            throw new System.NotImplementedException();
        }

        public float GetVisionAngle()
        {
            throw new System.NotImplementedException();
        }

        public SearchPath GetSearchPath()
        {
            throw new System.NotImplementedException();
        }

        public void SetRotation(Quaternion rotation)
        {
            throw new System.NotImplementedException();
        }

        public Vector3 GetSpawnLocation()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
