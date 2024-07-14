using UnityEngine;
using System.Collections.Generic;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { get; private set; }

    [System.Serializable]
    public class Resource
    {
        public string name;
        public int amount;
        public int capacity;
    }

    public List<Resource> resources = new List<Resource>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddResource(string resourceName, int amount)
    {
        Resource resource = resources.Find(r => r.name == resourceName);
        if (resource != null)
        {
            resource.amount = Mathf.Min(resource.amount + amount, resource.capacity);
        }
    }

    public bool UseResource(string resourceName, int amount)
    {
        Resource resource = resources.Find(r => r.name == resourceName);
        if (resource != null && resource.amount >= amount)
        {
            resource.amount -= amount;
            return true;
        }
        return false;
    }
}