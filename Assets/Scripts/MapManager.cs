using UnityEngine;

public class MapManager : MonoBehaviour
{
    public int mapIndex = 0;

    public void NextMap()
    {
        Transform currentMap = transform.GetChild(mapIndex);
        Transform nextMap = transform.GetChild(++mapIndex);

        currentMap.gameObject.SetActive(false);
        nextMap.gameObject.SetActive(true);
    }
}
