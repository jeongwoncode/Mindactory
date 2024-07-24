using UnityEngine;

namespace Mindustry
{
    public class ResourcePlacer : MonoBehaviour
    {
        public Grid grid;

        void Start()
        {
            AlignResourcesToGrid();
        }

        void AlignResourcesToGrid()
        {
            foreach (Transform child in transform)
            {
                Vector3Int cellPosition = grid.WorldToCell(child.position);
                Vector3 cellCenterPosition = grid.GetCellCenterWorld(cellPosition);
                child.position = cellCenterPosition;
            }
        }
    }
}
