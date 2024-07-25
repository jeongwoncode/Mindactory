using UnityEngine;

public class Miner : MonoBehaviour
{
    public float miningSpeed = 1f;
    private Resource currentResource;

    void Start()
    {
        FindResource();
    }

    void Update()
    {
        if (currentResource != null)
        {
            MineResource();
        }
        else
        {
            FindResource();
        }
    }

    void FindResource()
    {
        Vector3 position = transform.position;
        Collider2D[] colliders = Physics2D.OverlapPointAll(position);

        foreach (Collider2D collider in colliders)
        {
            Resource resource = collider.GetComponent<Resource>();
            if (resource != null)
            {
                currentResource = resource;
                Debug.Log("Resource found: " + resource.name);
                return;
            }
        }

        Debug.LogError("No resource found at this location.");
    }

    void MineResource()
    {
        if (currentResource != null)
        {
            currentResource.amount -= miningSpeed * Time.deltaTime;
            if (currentResource.amount <= 0)
            {
                Destroy(currentResource.gameObject);
                currentResource = null;
                Debug.Log("Resource depleted.");
            }
        }
    }
}
