using UnityEngine;

namespace Mindactory
{
    public class BuildingSelector : MonoBehaviour
    {
        private GameObject selectedBuilding;

        public GameObject GetSelectedBuilding()
        {
            return selectedBuilding;
        }

        public void SetSelectedBuilding(GameObject building)
        {
            selectedBuilding = building;
        }
    }
}
