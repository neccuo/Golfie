using UnityEngine;
using TMPro;

public class GameMediator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI parCounter;
    [SerializeField] private TextMeshProUGUI bounceCounter;

    [SerializeField] private MapManager mapManager;

    [SerializeField] private Ball ball;

    public void UpdateParCounterTxt(int parCountIn)
    {
        parCounter.text = "Par Counter: " + parCountIn;
    }

    public void UpdateBounceCounterTxt(int bounceCountIn)
    {
        bounceCounter.text = "Bounce Counter: " + bounceCountIn;
    }

    public void OpenNextMap()
    {
        mapManager.NextMap();
    }

}
