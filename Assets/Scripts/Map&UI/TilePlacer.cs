using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePlacer : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase tile;
    public Vector2Int gridSize = new Vector2Int(10, 10);

    void Start()
    {
        PlaceTiles();
    }

    void PlaceTiles()
    {
        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                Vector3Int tilePosition = new Vector3Int(x, y, 0);
                tilemap.SetTile(tilePosition, tile);
            }
        }
    }
}
