using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float speed = 1.0f;
    public Vector2 direction = Vector2.right;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("ResourceIngot"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = direction.normalized * speed;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ResourceIngot"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }
}
