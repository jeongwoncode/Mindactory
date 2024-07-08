using UnityEngine;

public class ConveyorBehaviour : MonoBehaviour
{
    public float speed = 1f;
    public Vector2 direction = Vector2.right;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Resource"))
        {
            other.transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}