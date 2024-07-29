using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorSystem : MonoBehaviour
{
    public GameObject conveyorPrefab;
    private GameObject selectedBuilding;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && selectedBuilding != null)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(conveyorPrefab, mousePosition, Quaternion.identity);
        }
    }

    public void SelectBuilding(GameObject building)
    {
        selectedBuilding = building;
        Debug.Log("Selected Building: " + building.name);
    }
}
