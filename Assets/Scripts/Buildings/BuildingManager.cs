using UnityEngine;

namespace Mindustry
{
    public class BuildingManager : MonoBehaviour
    {
        public GameObject minerPrefab;
        public GameObject smelterPrefab;

        private BuildingSelector buildingSelector;

        void Start()
        {
            buildingSelector = GetComponent<BuildingSelector>();
            if (buildingSelector == null)
            {
                Debug.LogError("BuildingSelector component is missing!");
            }
        }

        public void SelectMiner()
        {
            buildingSelector.SetSelectedBuilding(minerPrefab);
        }

        public void SelectSmelter()
        {
            buildingSelector.SetSelectedBuilding(smelterPrefab);
        }

        public GameObject GetSelectedBuilding()
        {
            return buildingSelector.GetSelectedBuilding();
        }
    }
}
