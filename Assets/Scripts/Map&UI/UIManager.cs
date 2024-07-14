using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Button minerButton;
    public Button smelterButton;
    public BuildingManager buildingManager;

    void Start()
    {
        if (minerButton == null)
        {
            Debug.LogError("Miner Button is not assigned!");
        }
        if (smelterButton == null)
        {
            Debug.LogError("Smelter Button is not assigned!");
        }
        if (buildingManager == null)
        {
            Debug.LogError("Building Manager is not assigned!");
        }
        
        minerButton.onClick.AddListener(OnMinerButtonClick);
        smelterButton.onClick.AddListener(OnSmelterButtonClick);
    }

    void OnMinerButtonClick()
    {
        buildingManager.SelectMiner();
    }

    void OnSmelterButtonClick()
    {
        buildingManager.SelectSmelter();
    }
}
