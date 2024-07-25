using UnityEngine;

public class Resource : MonoBehaviour
{
    public float amount = 100f;

    void Start()
    {
        if (amount <= 0)
        {
            Debug.LogError("Resource amount must be greater than 0.");
        }
    }
}
