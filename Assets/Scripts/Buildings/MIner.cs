using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Miner : MonoBehaviour
{
    public Tilemap resourceTilemap; // 자원 타일맵
    public GameObject ironIngotPrefab;
    public GameObject copperIngotPrefab;
    public float miningSpeed = 1.0f;

    private GameObject storedIngot;

    private void Start()
    {
        StartCoroutine(MineResource());
    }

    private IEnumerator MineResource()
    {
        while (true)
        {
            Vector3Int gridPosition = resourceTilemap.WorldToCell(transform.position);
            TileBase tile = resourceTilemap.GetTile(gridPosition);

            if (tile != null)
            {
                GameObject ingotPrefab = null;

                if (tile.name == "Ironore")
                {
                    ingotPrefab = ironIngotPrefab;
                }
                else if (tile.name == "Copperore")
                {
                    ingotPrefab = copperIngotPrefab;
                }

                if (ingotPrefab != null)
                {
                    // 자원 생성 및 저장
                    storedIngot = Instantiate(ingotPrefab, transform.position, Quaternion.identity);
                    storedIngot.SetActive(false);

                    // 인접한 컨베이어 확인
                    Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, 1f);
                    foreach (var hitCollider in hitColliders)
                    {
                        Conveyor conveyor = hitCollider.GetComponent<Conveyor>();
                        if (conveyor != null)
                        {
                            // 컨베이어에 자원 전달
                            conveyor.ReceiveIngot(storedIngot);
                            storedIngot = null;
                            break;
                        }
                    }
                }
            }

            yield return new WaitForSeconds(1f / miningSpeed);
        }
    }
}
