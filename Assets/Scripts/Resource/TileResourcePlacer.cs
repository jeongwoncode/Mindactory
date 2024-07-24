using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class TileResourcePlacer : MonoBehaviour
{
    public Tilemap tilemap;
    public IResourceFactory resourceFactory;
    public List<ResourceData> resources;

    void Start()
    {
        PlaceResources();
    }

    void PlaceResources()
    {
        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null)
                {
                    Vector3Int cellPosition = new Vector3Int(bounds.x + x, bounds.y + y, 0);
                    Vector3 worldPosition = tilemap.CellToWorld(cellPosition) + tilemap.tileAnchor;

                    foreach (ResourceData resourceData in resources)
                    {
                        if (tile.name == resourceData.resourceName)
                        {
                            resourceFactory.CreateResource(resourceData, worldPosition);
                        }
                    }
                }
            }
        }
    }
}
