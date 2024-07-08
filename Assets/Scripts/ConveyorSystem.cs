using UnityEngine;
using System.Collections.Generic;

public class ConveyorSystem : MonoBehaviour
{
    public static ConveyorSystem Instance { get; private set; }

    [System.Serializable]
    public class ConveyorItem
    {
        public string resourceName;
        public Transform itemTransform;
        public Vector2 startPosition;
        public Vector2 endPosition;
        public float speed;
    }

    public List<ConveyorItem> itemsOnConveyors = new List<ConveyorItem>();

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

    private void Update()
    {
        MoveItemsOnConveyors();
    }

    private void MoveItemsOnConveyors()
    {
        for (int i = itemsOnConveyors.Count - 1; i >= 0; i--)
        {
            ConveyorItem item = itemsOnConveyors[i];
            if (item.itemTransform == null)
            {
                itemsOnConveyors.RemoveAt(i);
                continue;
            }

            item.itemTransform.position = Vector2.MoveTowards(item.itemTransform.position, item.endPosition, item.speed * Time.deltaTime);

            if (Vector2.Distance(item.itemTransform.position, item.endPosition) < 0.01f)
            {
                // Item reached destination
                if (ResourceManager.Instance != null)
                {
                    ResourceManager.Instance.AddResource(item.resourceName, 1);
                }
                Destroy(item.itemTransform.gameObject);
                itemsOnConveyors.RemoveAt(i);
            }
        }
    }

    public void AddItemToConveyor(string resourceName, Vector2 start, Vector2 end, float speed)
    {
        GameObject itemObj = new GameObject("ConveyorItem_" + resourceName);
        if (itemObj != null)
        {
            itemObj.transform.position = start;

            ConveyorItem newItem = new ConveyorItem
            {
                resourceName = resourceName,
                itemTransform = itemObj.transform,
                startPosition = start,
                endPosition = end,
                speed = speed
            };

            itemsOnConveyors.Add(newItem);
        }
        else
        {
            Debug.LogError("Failed to create ConveyorItem GameObject");
        }
    }
}