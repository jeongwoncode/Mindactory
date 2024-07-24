using System.Collections.Generic; // HashSet을 사용하기 위해 추가
using UnityEngine;

namespace Mindustry
{
    public class BuildingPlacer : MonoBehaviour
    {
        public BuildingManager buildingManager;
        public Grid grid;
        private HashSet<Vector3Int> occupiedCells = new HashSet<Vector3Int>();

        void Update()
        {
            if (Input.GetMouseButtonDown(0) && !Utils.IsPointerOverUIElement())
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

                if (!occupiedCells.Contains(cellPosition))
                {
                    Vector3 cellCenterPosition = grid.GetCellCenterWorld(cellPosition);
                    GameObject building = Instantiate(selectedBuilding, cellCenterPosition, Quaternion.identity);
                    occupiedCells.Add(cellPosition);

                    // 자원과 가까운 위치에 건물 배치
                    Collider2D[] colliders = Physics2D.OverlapCircleAll(cellCenterPosition, 1f);
                    foreach (var collider in colliders)
                    {
                        if (collider.CompareTag("Resource"))
                        {
                            Miner miner = building.GetComponent<Miner>();
                            if (miner != null)
                            {
                                miner.SetTargetResource(collider.transform);
                            }
                            break;
                        }
                    }
                }
                else
                {
                    Debug.Log("Cell is already occupied!");
                }
            }
        }
    }
}
