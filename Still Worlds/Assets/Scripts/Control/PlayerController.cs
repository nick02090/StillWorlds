using Gameplay.Characters;
using UnityEngine;

namespace Control
{
    [RequireComponent(typeof(PlayerCharacter))]
    public class PlayerController : MonoBehaviour
    {
        public ParticleSystem WalkParticle;

        private ICharacter playerCharacter;

        private void Start()
        {
            // Initialize member variables
            playerCharacter = GetComponent<PlayerCharacter>();
        }

        private void FixedUpdate()
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
            } else
            {
                WalkParticle.Stop();
            }
        }

        public float deltaTime;
        private void Update()
        {
            deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
            float fps = 1.0f / deltaTime;
            Debug.Log(Mathf.Ceil(fps).ToString());
        }
    }
}
