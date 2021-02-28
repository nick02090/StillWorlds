using Gameplay.Characters;
using System.Collections;
using UnityEngine;

namespace Gameplay
{
    public class Bullet : MonoBehaviour
    {
        public ParticleSystem Explosion;
        public float waitForSeconds = 2.0f;
        public float speed = 8f;

        private void Update()
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                ICharacter enemyCharacter = other.GetComponent<ICharacter>();
                if (enemyCharacter.GetLife() == 1)
                {
                    // If player has killed an enemy, increase the kill counter
                    GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
                    ICharacter playerCharacter = playerGameObject.GetComponent<ICharacter>();
                    int currentPlayerKill = playerCharacter.GetKill();
                    currentPlayerKill++;
                    playerCharacter.SetKill(currentPlayerKill);
                }
                enemyCharacter.TakeHit();
                Explode();
            }
            if (other.CompareTag("Player"))
            {
                other.GetComponent<ICharacter>().TakeHit();
                Explode();
            }
        }

        private void OnEnable()
        {
            StartCoroutine(StartExplode());
        }

        private IEnumerator StartExplode()
        {
            yield return new WaitForSeconds(waitForSeconds);
            Explode();
        }

        private void Explode()
        {
            Explosion.transform.position = transform.position;
            Explosion.Play();
            Invoke("OnDisable", 0f);
        }

        private void OnDisable()
        {
            transform.gameObject.SetActive(false);
        }
    }
}
