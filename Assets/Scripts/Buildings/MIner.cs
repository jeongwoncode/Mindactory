using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Miner : MonoBehaviour
{
    public GameObject resourceIngotPrefab;
    public float miningSpeed = 1.0f;
    private Tilemap resourceTilemap;

    private void Start()
    {
        // 스크립트로 Tilemap 찾기
        resourceTilemap = GameObject.Find("ResourceTilemap").GetComponent<Tilemap>();
        StartCoroutine(MineResource());
    }

    private IEnumerator MineResource()
    {
        while (true)
        {
            Vector3Int cellPosition = resourceTilemap.WorldToCell(transform.position);
            TileBase resourceTile = resourceTilemap.GetTile(cellPosition);

            if (resourceTile != null)
            {
                // Ingot을 생성하여 컨베이어에 배치
                Instantiate(resourceIngotPrefab, transform.position, Quaternion.identity);
            }
            else
            {
                Debug.LogError("No resource found at this location.");
            }

            yield return new WaitForSeconds(1 / miningSpeed);
        }
    }
}
