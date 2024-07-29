using UnityEngine;

public class Ingot : MonoBehaviour
{
    public float moveSpeed = 1.0f;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Conveyor"))
        {
            Conveyor conveyor = other.GetComponent<Conveyor>();
            if (conveyor != null)
            {
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.velocity = conveyor.direction * conveyor.speed * moveSpeed;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Conveyor"))
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
        }
    }
}
