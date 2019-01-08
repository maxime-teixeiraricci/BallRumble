using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public Image mapImage;
    public MapSelectionEnum[] mapSelection;
    public int i;
	

}


[System.Serializable]
public struct MapSelectionEnum
{
    public Sprite image;
    public string sceneName;
    public string mapName;
}
