using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public GameObject minerPrefab;
    public GameObject smelterPrefab;
    private GameObject selectedBuilding;

    public void SelectMiner()
    {
        selectedBuilding = minerPrefab;
        Debug.Log("Miner selected");
    }

    public void SelectSmelter()
    {
        selectedBuilding = smelterPrefab;
        Debug.Log("Smelter selected");
    }

    public GameObject GetSelectedBuilding()
    {
        return selectedBuilding;
    }
}
