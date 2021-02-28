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

        private ICharacter playerCharacter;
        private bool isInteracting = false;

        private void Start()
        {
            // Initialize member variables
            playerCharacter = GetComponent<PlayerCharacter>();
        }

        private void FixedUpdate()
        {
            if (!isInteracting & playerCharacter.GetLife() > 0)
            {
                MovePlayer();
                Attack();
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
            }
            else
            {
                WalkParticle.Stop();
            }
        }

        private void Attack()
        {
            if (Input.GetMouseButtonDown(0))
            {
                playerCharacter.Attack();
            }
        }

        private void Update()
        {
            InteractWithNPC();
            InteractWithPortal();
            //ShowFPS();
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
