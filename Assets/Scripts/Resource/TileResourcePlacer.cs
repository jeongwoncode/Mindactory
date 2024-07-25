using UnityEngine;
using UnityEngine.Tilemaps;

public class TileResourcePlacer : MonoBehaviour
{
    public Tilemap resourceTilemap;
    public TileBase ironOreTile;
    public TileBase copperOreTile;

    public GameObject ironOrePrefab;
    public GameObject copperOrePrefab;

    void Start()
    {
        PlaceResources();
    }

    void PlaceResources()
    {
        BoundsInt bounds = resourceTilemap.cellBounds;
        TileBase[] allTiles = resourceTilemap.GetTilesBlock(bounds);

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile == ironOreTile)
                {
                    Vector3Int cellPosition = new Vector3Int(bounds.x + x, bounds.y + y, 0);
                    Vector3 worldPosition = resourceTilemap.CellToWorld(cellPosition) + resourceTilemap.tileAnchor;
                    GameObject ironOre = Instantiate(ironOrePrefab, worldPosition, Quaternion.identity);
                    ironOre.tag = "Resource";
                    Debug.Log("Iron ore placed at: " + worldPosition);
                }
                else if (tile == copperOreTile)
                {
                    Vector3Int cellPosition = new Vector3Int(bounds.x + x, bounds.y + y, 0);
                    Vector3 worldPosition = resourceTilemap.CellToWorld(cellPosition) + resourceTilemap.tileAnchor;
                    GameObject copperOre = Instantiate(copperOrePrefab, worldPosition, Quaternion.identity);
                    copperOre.tag = "Resource";
                    Debug.Log("Copper ore placed at: " + worldPosition);
                }
            }
        }
    }
}
