using Core;
using Gameplay;
using Gameplay.Characters;
using Gameplay.Interactors;
using UnityEngine;

namespace Control
{
    [RequireComponent(typeof(PlayerCharacter))]
    public class PlayerController : MonoBehaviour
    {
        public ParticleSystem WalkParticle;
        public bool enableAttack = true;
        public PoolManager PoolManager;
        public GameObject PauseScreenPanel;

        public AudioClip attackSound;
        public AudioClip walkSound;

        private ICharacter playerCharacter;
        private bool isInteracting = false;
        private bool isPaused = false;

        private void Start()
        {
            // Initialize member variables
            playerCharacter = GetComponent<PlayerCharacter>();
        }

        private void FixedUpdate()
        {
            if (!isInteracting & !isPaused & playerCharacter.GetLife() > 0)
            {
                MovePlayer();
            }
        }

        public void MovePlayer()
        {
            // Move player (based on input)
            float vertical = Input.GetAxis("Vertical");
            float movementSpeed = playerCharacter.GetMovementSpeed();
            transform.Translate(0f, 0f, movementSpeed * vertical * Time.deltaTime);
            float horizontal = Input.GetAxis("Horizontal");
            float rotationSpeed = playerCharacter.GetRotationSpeed();
            transform.Rotate(transform.up, rotationSpeed * horizontal * Time.deltaTime);

            // Play the walking particles
            if (vertical > 0.0f)
            {
                WalkParticle.Play();
                if (walkSound)
                    GetComponent<AudioSource>().PlayOneShot(walkSound);
            }
            else
            {
                WalkParticle.Stop();
            }
        }

        private void Update()
        {
            if (!isPaused)
            {
                InteractWithNPC();
                InteractWithPortal();
                if (!isInteracting & playerCharacter.GetLife() > 0)
                {
                    if (enableAttack)
                    {
                        Attack();
                    }

                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        StartPause();
                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    ResumePause();
                }
            }
            //ShowFPS();
        }

        public void StartPause()
        {
            isPaused = true;
            PauseScreenPanel.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
        }

        public void ResumePause()
        {
            isPaused = false;
            PauseScreenPanel.SetActive(false);
            Time.timeScale = 1f;
            Cursor.visible = false;
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        private void Attack()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (attackSound)
                    GetComponent<AudioSource>().PlayOneShot(attackSound);
                playerCharacter.Attack();
                PoolManager.CreateNext(GetComponent<Collider>(), transform.position + transform.forward + transform.up, transform.forward);
            }
        }

        public void InteractWithNPC()
        {
            Interactor interactor = playerCharacter.GetInteractor();
            if (interactor != null)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Start the interaction with the NPC
                    if (!isInteracting)
                    {
                        isInteracting = true;
                        interactor.Interact();
                    }
                    // Continue interaction with the NPC after another E press
                    else
                    {
                        isInteracting = interactor.ContinueInteraction();
                    }
                }
            }
        }

        public void InteractWithPortal()
        {
            Portal portal = playerCharacter.GetPortal();
            if (portal != null)
            {
                // Enter the portal
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameCore gameCore = GameObject.FindGameObjectWithTag("GameCore").GetComponent<GameCore>();
                    gameCore.playerLife = playerCharacter.GetLife();
                    gameCore.playerKill = playerCharacter.GetKill();
                    portal.Interact();
                }
            }
        }

        public float deltaTime;
        private void ShowFPS()
        {
            deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
            float fps = 1.0f / deltaTime;
            Debug.Log(Mathf.Ceil(fps).ToString());
        }
    }
}
