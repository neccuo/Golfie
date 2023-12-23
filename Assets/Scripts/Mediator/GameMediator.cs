using UnityEngine;
using TMPro;

public class GameMediator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI parCounter;
    [SerializeField] private MapManager mapManager;


    public void UpdateParCounterTxt(int parCountIn)
    {
        parCounter.text = "Par Counter: " + parCountIn;
    }

    public void OpenNextMap()
    {
        mapManager.NextMap();
    }
}
