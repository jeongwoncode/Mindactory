using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button minerButton;
    public Button smelterButton;
    public BuildingManager buildingManager;

    void Start()
    {
        minerButton.onClick.AddListener(buildingManager.SelectMiner);
        smelterButton.onClick.AddListener(buildingManager.SelectSmelter);
    }
}
