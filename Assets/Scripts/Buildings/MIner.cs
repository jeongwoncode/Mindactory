using UnityEngine;

namespace Mindustry
{
    public class Miner : MonoBehaviour
    {
        public float mineSpeed = 1f;
        private Transform targetResource;

        void Start()
        {
            InvokeRepeating(nameof(Mine), 1f, mineSpeed);
        }

        public void SetTargetResource(Transform resource)
        {
            targetResource = resource;
        }

        void Mine()
        {
            if (targetResource == null)
            {
                Debug.LogError("Target Resource is not assigned!");
                return;
            }

            // 자원 채굴 로직 구현
            Debug.Log("Mining resource: " + targetResource.name);
        }
    }
}
