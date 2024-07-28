using UnityEngine;

namespace Mindactory
{
    public interface IResourceFactory
    {
        ResourceData CreateResource(string resourceName, int amount, int capacity, GameObject prefab, Vector2 position);
    }
}
