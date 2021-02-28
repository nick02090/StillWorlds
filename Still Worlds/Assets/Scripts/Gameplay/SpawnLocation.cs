using UnityEngine;

namespace Gameplay
{
    public class SpawnLocation : MonoBehaviour
    {
        public Vector3 Location => transform.position;

        void OnDrawGizmosSelected()
        {
            // Draw a semitransparent blue cube at the transforms position
            Gizmos.color = new Color(0, 0, 1, 0.5f);
            Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
        }
    }
}
