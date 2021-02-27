using Gameplay.Characters;
using UnityEngine;
using static UnityEngine.ParticleSystem;

namespace Control
{
    [RequireComponent(typeof(PlayerCharacter))]
    public class PlayerController : MonoBehaviour
    {
        public ParticleSystem HatParticles;

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

            // Increase the hat particle speed when moving
            VelocityOverLifetimeModule velocityOverLifetime = HatParticles.velocityOverLifetime;
            velocityOverLifetime.speedModifier = vertical;
        }
    }
}
