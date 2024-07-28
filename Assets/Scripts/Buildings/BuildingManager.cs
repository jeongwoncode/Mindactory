using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public BuildingPlacer buildingPlacer;

    public void SelectMiner()
    {
        if (buildingPlacer != null)
        {
            buildingPlacer.SelectBuilding(buildingPlacer.minerPrefab);
        }
        else
        {
            Debug.LogError("BuildingPlacer is not assigned!");
        }
    }

    public void SelectSmelter()
    {
        if (buildingPlacer != null)
        {
            buildingPlacer.SelectBuilding(buildingPlacer.smelterPrefab);
        }
        else
        {
            Debug.LogError("BuildingPlacer is not assigned!");
        }
    }

        public void SelectConveyor()
    {
        if (buildingPlacer != null)
        {
            buildingPlacer.SelectBuilding(buildingPlacer.conveyorPrefab);
        }
        else
        {
            Debug.LogError("BuildingPlacer is not assigned!");
        }
    }
}
