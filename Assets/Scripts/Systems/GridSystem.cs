using UnityEngine;

public class GridSystem : MonoBehaviour
{
    public int width = 20;
    public int height = 20;
    public float cellSize = 1f;
    public GameObject tilePrefab;

    private GameObject[,] grid;

    void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        grid = new GameObject[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector2 worldPosition = GetWorldPosition(x, y);
                GameObject tile = Instantiate(tilePrefab, worldPosition, Quaternion.identity);
                tile.transform.SetParent(transform);
                tile.name = $"Tile_{x}_{y}";
                grid[x, y] = tile;
            }
        }
    }

    public Vector2 GetWorldPosition(int x, int y)
    {
        return new Vector2(x * cellSize, y * cellSize);
    }

    public void GetXY(Vector2 worldPosition, out int x, out int y)
    {
        x = Mathf.FloorToInt(worldPosition.x / cellSize);
        y = Mathf.FloorToInt(worldPosition.y / cellSize);
    }

    public bool CanPlaceBuilding(int x, int y, int buildingSize)
    {
        if (x < 0 || y < 0 || x + buildingSize > width || y + buildingSize > height)
            return false;

        for (int i = 0; i < buildingSize; i++)
        {
            for (int j = 0; j < buildingSize; j++)
            {
                if (grid[x + i, y + j].GetComponent<Tile>().isOccupied)
                    return false;
            }
        }
        return true;
    }

    public void PlaceBuilding(int x, int y, int buildingSize, GameObject buildingPrefab)
    {
        if (CanPlaceBuilding(x, y, buildingSize))
        {
            Vector2 buildingPosition = GetWorldPosition(x, y) + new Vector2(buildingSize * cellSize / 2, buildingSize * cellSize / 2);
            GameObject building = Instantiate(buildingPrefab, buildingPosition, Quaternion.identity);

            for (int i = 0; i < buildingSize; i++)
            {
                for (int j = 0; j < buildingSize; j++)
                {
                    grid[x + i, y + j].GetComponent<Tile>().isOccupied = true;
                }
            }
        }
    }
}

public class Tile : MonoBehaviour
{
    public bool isOccupied = false;
}