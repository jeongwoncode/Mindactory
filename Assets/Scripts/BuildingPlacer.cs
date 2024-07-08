using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{
    public GridSystem gridSystem;
    public GameObject buildingPrefab;
    public int buildingSize = 3;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            int x, y;
            gridSystem.GetXY(mousePosition, out x, out y);
            gridSystem.PlaceBuilding(x, y, buildingSize, buildingPrefab);
        }
    }
}