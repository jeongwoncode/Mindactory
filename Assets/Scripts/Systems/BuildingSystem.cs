using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem Instance;

    public GameObject buildingPrefab;
    private GameObject currentBuilding;
    private bool isPlacing;

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

    private void Update()
    {
        if (isPlacing)
        {
            MoveBuildingToMouse();
            if (Input.GetMouseButtonDown(0))
            {
                PlaceBuilding();
            }
        }
    }

    public void StartPlacingBuilding(GameObject building)
    {
        if (currentBuilding != null)
        {
            Destroy(currentBuilding);
        }
        currentBuilding = Instantiate(building);
        isPlacing = true;
    }

    private void MoveBuildingToMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        currentBuilding.transform.position = mousePosition;
    }

    private void PlaceBuilding()
    {
        isPlacing = false;
        currentBuilding = null;
    }
}
