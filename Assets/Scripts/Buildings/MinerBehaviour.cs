using UnityEngine;

public class MinerBehaviour : MonoBehaviour
{
    // 예제 속성들
    public Transform targetResource;

    void Start()
    {
        if (targetResource == null)
        {
            Debug.LogError("Target Resource is not assigned!");
        }
    }

    public void Mine()
    {
        if (targetResource != null)
        {
            // Mining 로직
        }
        else
        {
            Debug.LogError("Cannot mine because targetResource is null!");
        }
    }
}
