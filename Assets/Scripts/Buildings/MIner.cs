using UnityEngine;

namespace Mindactory
{
    public class Miner : MonoBehaviour
    {
        public Vector3Int position;
        public ResourceManager resourceManager;

        void Start()
        {
            resourceManager = FindObjectOfType<ResourceManager>();
            CheckResource();
        }

        void CheckResource()
        {
            Vector2Int cellPosition = (Vector2Int)position; // 변경된 부분
            ResourceData resource = resourceManager.GetResourceAtPosition(cellPosition);

            if (resource != null)
            {
                Debug.Log("Resource found: " + resource.ResourceName);
            }
            else
            {
                Debug.LogError("No resource found at this location.");
            }
        }
    }
}
