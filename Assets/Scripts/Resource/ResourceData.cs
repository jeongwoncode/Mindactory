using UnityEngine;

[CreateAssetMenu(fileName = "ResourceData", menuName = "ScriptableObjects/ResourceData", order = 1)]
public class ResourceData : ScriptableObject
{
    public string resourceName;
    public int amount;
    public int capacity;
    public GameObject resourcePrefab;
    public Vector2 position;  // 자원의 위치를 저장할 필드 추가
}
