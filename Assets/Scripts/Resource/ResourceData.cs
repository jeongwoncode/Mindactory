using UnityEngine;

namespace Mindactory
{
    [CreateAssetMenu(fileName = "ResourceData", menuName = "ScriptableObjects/ResourceData", order = 1)]
    public class ResourceData : ScriptableObject
    {
        public string ResourceName;
        public int Amount;
        public int Capacity;
        public GameObject ResourcePrefab;
        public Vector2 Position;
    }
}
