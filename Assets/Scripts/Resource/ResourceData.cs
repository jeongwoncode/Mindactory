using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "New Resource", menuName = "Resource Data")]
public class ResourceData : ScriptableObject
{
    public string resourceName;
    public int amount;
    public int capacity;
    public GameObject resourcePrefab;
    public Vector3Int position;
    public TileBase tile;
}
