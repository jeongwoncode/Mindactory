using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    private GameObject selectedBuilding;
    public float speed = 1.0f; // Conveyor belt speed
    public Vector2 direction = Vector2.right; // Direction of the conveyor belt

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Resource"))
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
        if (collision.CompareTag("Resource"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && selectedBuilding != null)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(selectedBuilding, mousePosition, Quaternion.identity);
        }
    }

}
