using UnityEngine;

public class SmelterBehaviour : MonoBehaviour
{
    public float processTime = 3f;
    public string inputResource = "Iron";
    public string outputResource = "Steel";
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= processTime)
        {
            Process();
            timer = 0f;
        }
    }

    private void Process()
    {
        if (ResourceManager.Instance.UseResource(inputResource, 1))
        {
            ResourceManager.Instance.AddResource(outputResource, 1);
            ConveyorSystem.Instance.AddItemToConveyor(outputResource, transform.position, transform.position + Vector3.right, 1f);
        }
    }
}