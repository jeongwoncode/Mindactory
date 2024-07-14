using System.Collections.Generic; // HashSet을 사용하기 위해 추가
using UnityEngine;

public class BuildingPlacer : MonoBehaviour
{
    public BuildingManager buildingManager;
    public Grid grid;
    private HashSet<Vector3Int> occupiedCells = new HashSet<Vector3Int>();

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlaceBuilding();
        }
    }

    void PlaceBuilding()
    {
        GameObject selectedBuilding = buildingManager.GetSelectedBuilding();
        if (selectedBuilding != null)
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPosition = grid.WorldToCell(mouseWorldPos);

            // 현재 셀이 점유되지 않은 경우에만 건물 배치
            if (!occupiedCells.Contains(cellPosition))
            {
                Vector3 cellCenterPosition = grid.GetCellCenterWorld(cellPosition);
                Instantiate(selectedBuilding, cellCenterPosition, Quaternion.identity);
                occupiedCells.Add(cellPosition);
            }
            else
            {
                Debug.Log("Cell is already occupied!");
            }
        }
    }
}
