using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smelter : MonoBehaviour
{
    public GameObject newIngotPrefab;
    public float smeltingSpeed = 1.0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ResourceIngot"))
        {
            StartCoroutine(ProcessResource(collision.gameObject));
        }
    }

    private IEnumerator ProcessResource(GameObject resourceIngot)
    {
        Destroy(resourceIngot);
        yield return new WaitForSeconds(1 / smeltingSpeed);
        Instantiate(newIngotPrefab, transform.position, Quaternion.identity);
    }
}
