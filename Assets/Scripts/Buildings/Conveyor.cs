using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float speed = 1.0f; // 컨베이어 속도
    public Vector2 direction = Vector2.down; // 기본 이동 방향

    private void OnTriggerStay2D(Collider2D collision)
    {
        // Ingot 태그를 가진 오브젝트가 벨트에 닿았을 때
        if (collision.CompareTag("Ingot"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // 자원의 속도를 컨베이어 방향으로 설정
                rb.velocity = direction.normalized * speed;
            }
        }

        // Miner 태그를 가진 오브젝트가 벨트에 닿았을 때 로그 출력
        if (collision.CompareTag("Miner"))
        {
            Debug.Log("Miner가 Conveyor에 닿았습니다.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 벨트에서 자원이 벗어나면 멈추게 함
        if (collision.CompareTag("Ingot"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    // 컨베이어가 Ingot을 받았을 때의 동작
    public void ReceiveIngot(GameObject ingotPrefab)
    {
        Vector2 spawnPosition = transform.position;
        GameObject ingot = Instantiate(ingotPrefab, spawnPosition, Quaternion.identity);
        ingot.GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;
    }
}
