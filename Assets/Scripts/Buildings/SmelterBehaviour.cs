using UnityEngine;

namespace Mindactory
{
    public class SmelterBehaviour : MonoBehaviour
    {
        public float processingTime = 2f; // Smelter processing time
        private float processTimer = 0f;
        private bool isProcessing = false;
        private ResourceManager resourceManager;

        void Start()
        {
            resourceManager = FindObjectOfType<ResourceManager>();
        }

        void Update()
        {
            if (isProcessing)
            {
                processTimer += Time.deltaTime;
                if (processTimer >= processingTime)
                {
                    Process();
                    processTimer = 0f;
                    isProcessing = false;
                }
            }
        }

        void OnMouseDown()
        {
            Vector2 position = new Vector2(transform.position.x, transform.position.y);
            ResourceData resource = resourceManager.GetResourceAtPosition(position);
            if (resource != null)
            {
                isProcessing = true;
            }
            else
            {
                Debug.LogError("No resource found at this location.");
            }
        }

        private void Process()
        {
            // Process the resource
            Vector2 position = new Vector2(transform.position.x, transform.position.y);
            ResourceData resource = resourceManager.GetResourceAtPosition(position);
            if (resource != null)
            {
                resourceManager.CollectResource(resource);
                Debug.Log("Resource processed!");
            }
            else
            {
                Debug.LogError("No resource found at this location.");
            }
        }
    }
}
