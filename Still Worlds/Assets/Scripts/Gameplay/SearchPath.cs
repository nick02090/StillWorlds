using UnityEngine;

namespace Gameplay
{
    public class SearchPath : MonoBehaviour
    {
        public WorldPoint[] pathPoints;

        private int index;
        private int size;

        private void Awake()
        {
            index = 0;
            size = pathPoints.Length;
        }

        public Vector3 GetNext()
        {
            // Calculate the location
            Vector3 location = pathPoints[index].Location;
            // Calculate the next index
            index = (index + 1) % size;
            return location;
        }
    }
}
