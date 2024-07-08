using UnityEngine;

public class MinerBehaviour : MonoBehaviour
{
    public float miningRate = 1f; // 초당 채굴량
    public string resourceType = "Iron"; // 채굴할 자원 유형
    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f / miningRate)
        {
            Mine();
            timer = 0f;
        }
    }

    private void Mine()
    {
        ResourceManager.Instance.AddResource(resourceType, 1);
        ConveyorSystem.Instance.AddItemToConveyor(resourceType, transform.position, transform.position + Vector3.right, 1f);
    }
}