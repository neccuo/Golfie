using UnityEngine;
using TMPro;

public class GameUIMediator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI parCounter;

    public void UpdateParCounterTxt(int parCountIn)
    {
        parCounter.text = "Par Counter: " + parCountIn;
    }
}
