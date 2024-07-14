using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapLoader : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase[] tiles; // 타일 배열

    void Start()
    {
        LoadTilemap();
    }

    void LoadTilemap()
    {
        for (int x = -10; x < 10; x++)
        {
            for (int y = -10; y < 10; y++)
            {
                int index = Random.Range(0, tiles.Length);
                tilemap.SetTile(new Vector3Int(x, y, 0), tiles[index]);
            }
        }
    }
}
