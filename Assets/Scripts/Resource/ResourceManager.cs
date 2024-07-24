using UnityEngine;
using System.Collections.Generic;

namespace Mindustry
{
    public class ResourceManager : MonoBehaviour
    {
        public List<ResourceData> resources; // 여러 자원 데이터를 관리하기 위한 리스트
        public Grid grid;
        public Vector2Int gridSize = new Vector2Int(10, 10);

        void Start()
        {
            PlaceResources();
        }

        void PlaceResources()
        {
            HashSet<Vector2Int> placedPositions = new HashSet<Vector2Int>();

            foreach (ResourceData resourceData in resources)
            {
                Vector3 cellCenterPosition = grid.GetCellCenterWorld((Vector3Int)grid.WorldToCell((Vector3)resourceData.position));
                Instantiate(resourceData.resourcePrefab, cellCenterPosition, Quaternion.identity);
                placedPositions.Add(Vector2Int.RoundToInt(resourceData.position));
            }
        }
    }
}
