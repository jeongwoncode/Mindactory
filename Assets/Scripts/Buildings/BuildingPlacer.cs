using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class BuildingPlacer : MonoBehaviour
{
    public Tilemap mapTilemap;
    public Tilemap resourceTilemap;
    public GameObject minerPrefab;
    public GameObject smelterPrefab;
    private GameObject selectedBuilding;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // UI 요소 클릭 여부를 확인
            if (IsPointerOverUIObject())
            {
                return;
            }

            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cellPos = mapTilemap.WorldToCell(mouseWorldPos);
            PlaceBuilding(cellPos);
        }
    }

    public void SelectBuilding(GameObject building)
    {
        selectedBuilding = building;
        Debug.Log("Selected Building: " + building.name);
    }

    void PlaceBuilding(Vector3Int cellPos)
    {
        if (selectedBuilding == null) return;

        Vector3 cellCenterPos = mapTilemap.GetCellCenterWorld(cellPos);
        TileBase tile = resourceTilemap.GetTile(cellPos);
        Debug.Log("Placing building at cell position: " + cellPos);

        if (selectedBuilding == minerPrefab)
        {
            if (tile != null)
            {
                Instantiate(selectedBuilding, cellCenterPos, Quaternion.identity);
                Debug.Log("Miner placed at: " + cellCenterPos);
            }
            else
            {
                Debug.Log("Miner can only be placed on resource tiles.");
            }
        }
        else if (selectedBuilding == smelterPrefab)
        {
            Instantiate(selectedBuilding, cellCenterPos, Quaternion.identity);
            Debug.Log("Smelter placed at: " + cellCenterPos);
        }
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
