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
                //Health enemyHealth = other.GetComponent<Health>();
                //enemyHealth.TakeDamage(20);
                StartCoroutine(Explode());
                //Invoke("OnDisable", 0f);
            }
            if (other.CompareTag("Mine"))
            {
                //Health mineHealth = other.GetComponent<Health>();
                //mineHealth.TakeDamage(40);
                StartCoroutine(Explode());
                //Invoke("OnDisable", 0f);
            }
        }

        private void OnEnable()
        {
            StartCoroutine(Explode());
            //Invoke("OnDisable", waitForSeconds);
        }

        private IEnumerator Explode()
        {
            yield return new WaitForSeconds(waitForSeconds);
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
