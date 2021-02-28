using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class PoolManager : MonoBehaviour
    {
        public GameObject bullet;
        public int spawnCount;

        public List<GameObject> bulletList;

        private void Awake()
        {
            for (int i = 0; i < spawnCount; i++)
            {
                GameObject bullet = Instantiate(this.bullet);
                bulletList.Add(bullet);
                bullet.transform.parent = transform;
                bullet.SetActive(false);
            }
        }

        public void CreateNext(Collider ignoreCollider, Vector3 spawnPosition, Vector3 spawnForward)
        {
            for (int i = 0; i < bulletList.Count; i++)
            {
                if (!bulletList[i].activeInHierarchy)
                {
                    bulletList[i].SetActive(true);
                    Physics.IgnoreCollision(bulletList[i].GetComponent<Collider>(), ignoreCollider);
                    bulletList[i].transform.position = spawnPosition;
                    bulletList[i].transform.forward = spawnForward;
                    break;
                }
                else
                {
                    // last bullet existing
                    if (i == bulletList.Count - 1)
                    {
                        GameObject newBullet = Instantiate(bullet);
                        newBullet.transform.parent = transform;
                        newBullet.SetActive(false);
                        bulletList.Add(newBullet);
                    }
                }
            }
        }
    }
}
