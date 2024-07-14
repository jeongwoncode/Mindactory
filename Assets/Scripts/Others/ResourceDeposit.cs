using UnityEngine;

public class ResourceDeposit : MonoBehaviour
{
    public string resourceType = "Iron";
    public int amount = 1000;

    public bool Extract(int extractAmount)
    {
        if (amount >= extractAmount)
        {
            amount -= extractAmount;
            return true;
        }
        return false;
    }
}