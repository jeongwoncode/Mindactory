using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }
    public Tilemap resourceTilemap;
    public List<ResourceData> resources;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public ResourceData GetResourceAtPosition(Vector3Int position)
    {
        foreach (var resource in resources)
        {
            if (resource.position == position)
            {
                return resource;
            }
        }
        return null;
    }

    public void CollectResource(Vector3Int position, int amount)
    {
        var resource = GetResourceAtPosition(position);
        if (resource != null)
        {
            resource.amount -= amount;
            if (resource.amount <= 0)
            {
                resources.Remove(resource);
                resourceTilemap.SetTile(position, null);
                Destroy(resource.resourcePrefab);
            }
        }
    }
}
