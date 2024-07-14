using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float smoothTime = 0.1f;
    public Camera mainCamera;

    private Vector2 movement;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on the player!");
        }

        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    private void Update()
    {
        // 입력 처리
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Debug.Log($"Input: {movement}"); // 입력값 로그
    }

    private void FixedUpdate()
    {
        // 플레이어 이동
        if (rb != null)
        {
            Vector2 newPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;
            rb.MovePosition(newPosition);
            //Debug.Log($"New Position: {newPosition}"); // 새 위치 로그
        }
    }
}