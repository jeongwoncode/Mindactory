using UnityEngine;
using UnityEngine.UI;

namespace Mindustry
{
    public class UIManager : MonoBehaviour
    {
        public Button minerButton;
        public Button smelterButton;
        public BuildingManager buildingManager;

        void Start()
        {
            if (buildingManager == null)
            {
                Debug.LogError("BuildingManager is not assigned!");
                return;
            }

            if (minerButton != null)
            {
                minerButton.onClick.AddListener(OnMinerButtonClick);
            }
            else
            {
                Debug.LogError("Miner Button is not assigned!");
            }

            if (smelterButton != null)
            {
                smelterButton.onClick.AddListener(OnSmelterButtonClick);
            }
            else
            {
                Debug.LogError("Smelter Button is not assigned!");
            }
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
}
