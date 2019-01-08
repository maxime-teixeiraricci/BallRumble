using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapSelectorScript : MonoBehaviour
{
    public int id;
    public MapManager mapManager;
    private MapSelectionEnum map;

    [Header("Object")]
    public Text textMap;
    public Image imageMap;
    


	// Use this for initialization
	void Update ()
    {
        map = mapManager.mapSelection[id];
        textMap.text = map.mapName;
        imageMap.sprite = map.image;

    }

    public void StartGame()
    {
        SceneManager.LoadScene(map.sceneName);
    }


    public void NextMap()
    {
        id = (id + 1) % mapManager.mapSelection.Length;
    }

    public void BeforeMap()
    {
        id = (id - 1 + mapManager.mapSelection.Length) % mapManager.mapSelection.Length;
    }

}
