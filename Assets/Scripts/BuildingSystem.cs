using UnityEngine;
using System.Collections.Generic;

public class BuildingSystem : MonoBehaviour
{
    public static BuildingSystem Instance { get; private set; }

    [System.Serializable]
    public class ResourceCost
    {
        public string resourceName;
        public int amount;
    }

    [System.Serializable]
    public class Building
    {
        public string name;
        public GameObject prefab;
        public List<ResourceCost> cost = new List<ResourceCost>();
    }

    public List<Building> availableBuildings = new List<Building>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool CanPlaceBuilding(Building building, Vector2 position)
    {
        // 위치가 유효하고 자원이 사용 가능한지 확인
        return true; // 임시 플레이스홀더
    }

    public void PlaceBuilding(Building building, Vector2 position)
    {
        if (CanPlaceBuilding(building, position))
        {
            // 자원 차감
            foreach (var resource in building.cost)
            {
                ResourceManager.Instance.UseResource(resource.resourceName, resource.amount);
            }

            // 건물 인스턴스화
            Instantiate(building.prefab, position, Quaternion.identity);
        }
    }
}