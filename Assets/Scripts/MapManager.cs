using UnityEngine;

public class MapManager : MonoBehaviour
{
    public int mapCount = 0;
    public int mapIndex = 0;

    public void Start()
    {
        mapCount = transform.childCount;
        // Open the first map
        ToggleMap(mapIndex, true);
    }

    public void NextMap()
    {
        ToggleMap(mapIndex, false);
        mapIndex = (mapIndex + 1) % mapCount;
        ToggleMap(mapIndex, true);
    }

    /// Open or close a map given map index
    private void ToggleMap(int indexIn, bool isOpenCmdIn)
    {
        Transform map = transform.GetChild(indexIn);
        if(isOpenCmdIn)
        {
            string mapName = map.gameObject.name;
            Debug.Log("Opening map: " + mapName);
        }
        map.gameObject.SetActive(isOpenCmdIn);
    }

}
